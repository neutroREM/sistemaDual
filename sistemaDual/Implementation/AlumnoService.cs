using Microsoft.EntityFrameworkCore;
using sistemaDual.Interfaces;
using sistemaDual.Models;
using System.Net;
using System.Text;

namespace sistemaDual.Implementation
{
    public class AlumnoService : IAlumnoService
    {
        private readonly IGenericRespository<AlumnoDual> _repository;
        private readonly IUtilidadesService _utilidadesService;
        private readonly ICorreoService _correoService;

        public AlumnoService(IGenericRespository<AlumnoDual> repository, IUtilidadesService utilidadesService, ICorreoService correoService)
        {
            _repository = repository;
            _utilidadesService = utilidadesService;
            _correoService = correoService;
        }

        public async Task<List<AlumnoDual>> Lista()
        {
            IQueryable<AlumnoDual> query = await _repository.Consultar();
            return query.Include(r => r.Rol)
                .Include(e => e.Estatus)
                .ToList();
        }

        public async Task<AlumnoDual> Crear(AlumnoDual entidad, string urlPlantillaCorreo = "")
        {
            AlumnoDual alumno_existe = await _repository.Obtener(u => u.Correo == entidad.Correo);
            if(alumno_existe != null)
            {
                throw new TaskCanceledException("El correo ya esta registrado");
            }
            
            try
            {
                string clave_generada = _utilidadesService.GenerarClave();
                entidad.Clave = _utilidadesService.ConvertirSha256(clave_generada);
                entidad.FechaRegistro = DateTime.Now;
                AlumnoDual alumnoDual = await _repository.Crear(entidad);

                if (alumnoDual.AlumnoDualID == 0)
                    throw new TaskCanceledException("No se pudo registrar el Estudiante");

                if (urlPlantillaCorreo != "")
                {
                    urlPlantillaCorreo = urlPlantillaCorreo.Replace("[correo]", alumnoDual.Correo).Replace("[clave]", clave_generada);
                    
                    string htmlCorreo = "";

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlPlantillaCorreo);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream dataStream = response.GetResponseStream())
                        {
                            StreamReader reader = null;
                            if(response.CharacterSet == null)
                                reader = new StreamReader(dataStream);
                            else
                                reader = new StreamReader(dataStream,Encoding.GetEncoding(response.CharacterSet));

                            htmlCorreo = reader.ReadToEnd();
                            response.Close();
                            reader.Close();
                        }
                    }
                    if(htmlCorreo != "")
                        await _correoService.EnviarCorreo(alumnoDual.Correo, "Cuenta registrada", htmlCorreo);
                }
                IQueryable<AlumnoDual> query = await _repository.Consultar(u => u.AlumnoDualID == alumnoDual.AlumnoDualID);
                alumnoDual = query.Include(r => r.Rol)
                    .Include(e => e.Estatus)
                    .First();
                 
                return alumnoDual;
            }

            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<AlumnoDual> Editar(AlumnoDual entidad)
        {
            AlumnoDual alumno_existe = await _repository.Obtener(u => u.Correo == entidad.Correo&& u.AlumnoDualID != entidad.AlumnoDualID);
            if (alumno_existe != null)
                throw new TaskCanceledException("El correo ya esta registrado");

            try
            {
                IQueryable<AlumnoDual> query = await _repository.Consultar(u => u.AlumnoDualID == entidad.AlumnoDualID);
                
                AlumnoDual alumno_editar = query.First();
                alumno_editar.CURP = entidad.CURP;
                alumno_editar.Matricula = entidad.Matricula;
                alumno_editar.NombreA = entidad.NombreA;
                alumno_editar.ApellidoP = entidad.ApellidoP;
                alumno_editar.ApellidoM = entidad.ApellidoM;
                alumno_editar.Telefono = entidad.Telefono;
                alumno_editar.Correo = entidad.Correo;
                alumno_editar.RolID = entidad.RolID;
                alumno_editar.EsActivo = entidad.EsActivo;
                alumno_editar.EstatusID = entidad.EstatusID;
                alumno_editar.FechaCambios = DateTime.Now;

                bool resp = await _repository.Editar(alumno_editar);

                if (!resp)
                    throw new TaskCanceledException("No se modifico el Alumno");

                AlumnoDual alumno_editado = query.Include(r => r.Rol)
                    .Include(e => e.Estatus)
                    .First();

                return alumno_editado;
                 
            }
            catch
            {
                throw;
            }
        }

        async Task<bool> IAlumnoService.Eliminar(int AlumnoDualID)
        {
            try
            {
                AlumnoDual alumno_encontrado = await _repository.Obtener(u => u.AlumnoDualID == AlumnoDualID);

                if (alumno_encontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                bool resp = await _repository.Eliminar(alumno_encontrado);
                return true;
            }
            catch
            {
                throw;
            }
        }

        async Task<AlumnoDual> IAlumnoService.ObtenerXCredenciales(string correo, string clave)
        {
            string clave_encriptada = _utilidadesService.ConvertirSha256(clave);

            AlumnoDual alumno_encontrado = await _repository.Obtener(u => u.Correo.Equals(correo) && u.Clave.Equals(clave_encriptada));

            return alumno_encontrado;
        }


        async Task<AlumnoDual> IAlumnoService.ObtenerXCurp(string curp)
        {
            IQueryable<AlumnoDual> query = await _repository.Consultar(u => u.CURP == curp);
            AlumnoDual result = query.Include(r => r.Rol).FirstOrDefault();

            return result;
        }

        async Task<bool> IAlumnoService.GuardarPeril(AlumnoDual entidad)
        {
            try
            {
                AlumnoDual alumno_encontrado = await _repository.Obtener(u => u.AlumnoDualID == entidad.AlumnoDualID);

                if (alumno_encontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                alumno_encontrado.Correo = entidad.Correo;
                alumno_encontrado.Telefono = entidad.Telefono;

                bool resp = await _repository.Editar(alumno_encontrado);
                return resp;
            }
            catch
            {
                throw;
            }
        }

        async Task<bool> IAlumnoService.CambiarClave(int alumnoID, string clave, string claveNueva)
        {
            try
            {
                AlumnoDual alumno_encontrado = await _repository.Obtener(u => u.AlumnoDualID == alumnoID);

                if(alumno_encontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                if(alumno_encontrado.Clave != _utilidadesService.ConvertirSha256(clave))
                    throw new TaskCanceledException("La contraseña ingresada como actual no es correcta");

                alumno_encontrado.Clave = _utilidadesService.ConvertirSha256(claveNueva);
                bool resp = await _repository.Editar(alumno_encontrado);

                return resp;

            }
            catch(Exception ex)
            {
                throw;
            }
        }

        async Task<bool> IAlumnoService.RestablecerClave(string correo, string urlPlantillaCorreo)
        {
            try
            {
                AlumnoDual alumno_encontrado = await _repository.Obtener(u => u.Correo == correo);

                if (alumno_encontrado == null)
                    throw new TaskCanceledException("No esta asociado a ningun correo");

                string clave_generada = _utilidadesService.GenerarClave();
                alumno_encontrado.Clave = _utilidadesService.ConvertirSha256(clave_generada);

                urlPlantillaCorreo = urlPlantillaCorreo.Replace("[clave]", clave_generada);

                string htmlCorreo = "";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlPlantillaCorreo);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        StreamReader reader = null;
                        if (response.CharacterSet == null)
                            reader = new StreamReader(dataStream);
                        else
                            reader = new StreamReader(dataStream, Encoding.GetEncoding(response.CharacterSet));

                        htmlCorreo = reader.ReadToEnd();
                        response.Close();
                        reader.Close();
                    }
                }
                bool correo_enviado = false;

                if (htmlCorreo != "")
                   correo_enviado = await _correoService.EnviarCorreo(correo, "Contraseña actualizada", htmlCorreo);

                if (!correo_enviado)
                    throw new TaskCanceledException("No se puedo enviar el correo, intenta mas tarde");

                bool resp = await _repository.Editar(alumno_encontrado);

                return resp;

            }
            catch
            {
                throw;
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using sistemaDual.Interfaces;
using sistemaDual.Models;
using System.Net;
using System.Text;

namespace sistemaDual.Implementation
{
    public class MentorEmpresarialService : IMentorEmpresarialService
    {
        private readonly IGenericRespository<MentorEmpresarial> _repository;
        private readonly IUtilidadesService _utilidadesService;
        private readonly ICorreoService _correoService;

        public MentorEmpresarialService(IGenericRespository<MentorEmpresarial> repository, IUtilidadesService utilidadesService, ICorreoService correoService)
        {
            _repository = repository;
            _utilidadesService = utilidadesService;
            _correoService = correoService;
        }

        public async Task<List<MentorEmpresarial>> Lista()
        {
            IQueryable<MentorEmpresarial> query = await _repository.Consultar();
            return query.Include(r => r.Empresa).ToList();
        }

        public async Task<MentorEmpresarial> Crear(MentorEmpresarial entidad, string urlPlantillaCorreo = "")
        {
            MentorEmpresarial mentor_existe = await _repository.Obtener(u => u.Correo == entidad.Correo);
            if (mentor_existe != null)
            {
                throw new TaskCanceledException("El correo ya esta registrado");
            }

            try
            {
                string clave_generada = _utilidadesService.GenerarClave();
                entidad.Clave = _utilidadesService.ConvertirSha256(clave_generada);
                //entidad.FechaRegistro = DateTime.Now;

                MentorEmpresarial nuevo_mentor = await _repository.Crear(entidad);

                if ( nuevo_mentor == null)
                    throw new TaskCanceledException("No se pudo registrar el Estudiante");

                if (urlPlantillaCorreo != "")
                {
                    urlPlantillaCorreo = urlPlantillaCorreo.Replace("[correo]", nuevo_mentor.Correo).Replace("[clave]", clave_generada);

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
                    if (htmlCorreo != "")
                        await _correoService.EnviarCorreo(nuevo_mentor.Correo, "Cuenta registrada", htmlCorreo);
                }
                IQueryable<MentorEmpresarial> query = await _repository.Consultar(u => u.MentorEmpresarialID == nuevo_mentor.MentorEmpresarialID);
                nuevo_mentor = query.Include(r => r.Empresa).First();

                return nuevo_mentor;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<MentorEmpresarial> Editar(MentorEmpresarial entidad)
        {
            MentorEmpresarial mentor_existe = await _repository.Obtener(u => u.Correo == entidad.Correo&& u.MentorEmpresarialID != entidad.MentorEmpresarialID);
            if (mentor_existe != null)
            {
                throw new TaskCanceledException("El correo ya esta registrado");
            }

            try
            {
                IQueryable<MentorEmpresarial> query = await _repository.Consultar(u => u.MentorEmpresarialID == entidad.MentorEmpresarialID);
                MentorEmpresarial editar_mentor = query.First();

                editar_mentor.CURP = entidad.CURP;
                editar_mentor.Nombre = entidad.Nombre;
                editar_mentor.ApellidoP = entidad.ApellidoP;
                editar_mentor.ApellidoM = entidad.ApellidoM;
                editar_mentor.Correo = entidad.Correo;
                editar_mentor.Telefono = entidad.Telefono;
                editar_mentor.Cargo = entidad.Cargo;
                editar_mentor.EmpresaID = entidad.EmpresaID;

                bool resp = await _repository.Editar(editar_mentor);
                if (!resp)
                    throw new TaskCanceledException("No se modifico el Alumno");

                MentorEmpresarial mentor_editado = query.Include(r => r.Empresa).First();

                return mentor_editado;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int MentorEmpresarialID)
        {
            try
            {
                MentorEmpresarial mentor_encontrado = await _repository.Obtener(u => u.MentorEmpresarialID == MentorEmpresarialID);

                if (mentor_encontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                bool resp = await _repository.Eliminar(mentor_encontrado);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<MentorEmpresarial> ObtenerXCredenciales(string correo, string clave)
        {
            string clave_encriptada = _utilidadesService.ConvertirSha256(clave);

            MentorEmpresarial mentor_encontrado = await _repository.Obtener(u => u.Correo.Equals(correo) && u.Clave.Equals(clave_encriptada));

            return mentor_encontrado;
        }

        public async Task<MentorEmpresarial> ObtenerXCurp(string curp)
        {
            IQueryable<MentorEmpresarial> query = await _repository.Consultar(u => u.CURP == curp);
            MentorEmpresarial result = query.Include(r => r.Empresa).FirstOrDefault();

            return result;
        }

        public async Task<bool> GuardarPeril(MentorEmpresarial entidad)
        {
            try
            {
                MentorEmpresarial mentor_encontrado = await _repository.Obtener(u => u.MentorEmpresarialID == entidad.MentorEmpresarialID);

                if (mentor_encontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                mentor_encontrado.Correo = entidad.Correo;
                mentor_encontrado.Telefono = entidad.Telefono;

                bool resp = await _repository.Editar(mentor_encontrado);
                return resp;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> CambiarClave(int mentorEmpresarialID, string clave, string claveNueva)
        {
            try
            {
                MentorEmpresarial mentor_encontrado = await _repository.Obtener(u => u.MentorEmpresarialID == mentorEmpresarialID);

                if (mentor_encontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                if (mentor_encontrado.Clave != _utilidadesService.ConvertirSha256(clave))
                    throw new TaskCanceledException("La contraseña ingresada como actual no es correcta");

                mentor_encontrado.Clave = _utilidadesService.ConvertirSha256(claveNueva);
                bool resp = await _repository.Editar(mentor_encontrado);

                return resp;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> RestablecerClave(string correo, string urlPlantillaCorreo = "")
        {
            try
            {
                MentorEmpresarial mentor_encontrado = await _repository.Obtener(u => u.Correo == correo);

                if (mentor_encontrado == null)
                    throw new TaskCanceledException("No esta asociado a ningun correo");

                string clave_generada = _utilidadesService.GenerarClave();
                mentor_encontrado.Clave = _utilidadesService.ConvertirSha256(clave_generada);

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

                bool resp = await _repository.Editar(mentor_encontrado);

                return resp;

            }
            catch
            {
                throw;
            }
        }
    }
}

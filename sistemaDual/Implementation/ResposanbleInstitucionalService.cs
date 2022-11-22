using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using sistemaDual.Interfaces;
using sistemaDual.Models;

namespace sistemaDual.Implementation
{
    public class ResposanbleInstitucionalService : IResponsableInstitucionalService
    {
        private readonly IGenericRespository<ResponsableInstitucional> _repository;

        public ResposanbleInstitucionalService(IGenericRespository<ResponsableInstitucional> repository)
        {
            _repository = repository;
        }


        public async Task<List<ResponsableInstitucional>> Lista()
        {
            IQueryable<ResponsableInstitucional> query = await _repository.Consultar();
            return query.Include(p => p.Universidad).ToList();
        }

        public async Task<ResponsableInstitucional> Crear(ResponsableInstitucional entidad)
        {
            ResponsableInstitucional resp_existe = await _repository.Obtener(i => i.ResponsableInstitucionalID == entidad.ResponsableInstitucionalID);
            if (resp_existe != null)
                throw new TaskCanceledException("Este usuario ya está registrado");

            try
            {
                ResponsableInstitucional nuevo_resp = await _repository.Crear(entidad);
                if (entidad.ResponsableInstitucionalID == 0)
                    throw new TaskCanceledException("No se puedo registrar el Mentor");

                IQueryable<ResponsableInstitucional> query = await _repository.Consultar(i => i.ResponsableInstitucionalID == nuevo_resp.ResponsableInstitucionalID);
                nuevo_resp = query.Include(p => p.Universidad).First();
                return nuevo_resp;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<ResponsableInstitucional> GuardarCambios(ResponsableInstitucional entidad)
        {

            ResponsableInstitucional resp_existe = await _repository.Obtener(i => i.ResponsableInstitucionalID == entidad.ResponsableInstitucionalID);
            if (resp_existe == null)
                throw new TaskCanceledException("Este usuario no está registrado");
            try
            {

                IQueryable<ResponsableInstitucional> query = await _repository.Consultar(i => i.ResponsableInstitucionalID == entidad.ResponsableInstitucionalID);
                ResponsableInstitucional responsable_encontrado = query.First();

                responsable_encontrado.CURP = entidad.CURP;
                responsable_encontrado.NombreR = entidad.NombreR;
                responsable_encontrado.ApellidoP = entidad.ApellidoP;
                responsable_encontrado.ApellidoM = entidad.ApellidoM;
                responsable_encontrado.Correo = entidad.Correo;
                responsable_encontrado.Telefono = entidad.Telefono;
                responsable_encontrado.Cargo = entidad.Cargo;
                responsable_encontrado.UniversidadID = entidad.UniversidadID;

                bool resp = await _repository.Editar(responsable_encontrado);

                if (!resp)
                    throw new TaskCanceledException("No se puedo editar el Responsable");

                ResponsableInstitucional resp_editado = query.Include(u => u.Universidad).First();
                return resp_editado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int responsableInstitucionaID)
        {
            try
            {
                ResponsableInstitucional eliminar_resp = await _repository.Obtener(i => i.ResponsableInstitucionalID == responsableInstitucionaID);
                if (eliminar_resp == null)
                    throw new TaskCanceledException("El usuario que desea eliminar no esta registrado");

                bool resp = await _repository.Eliminar(eliminar_resp);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}

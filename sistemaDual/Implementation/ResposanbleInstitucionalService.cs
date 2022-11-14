using Microsoft.EntityFrameworkCore;
using sistemaDual.Interfaces;
using sistemaDual.Models;

namespace sistemaDual.Implementation
{
    public class ResposanbleInstitucionalService : IResponsableInstitucionalService
    {
        private readonly IGenericRespository<ResponsableInstitucional> _respository;

        public ResposanbleInstitucionalService(IGenericRespository<ResponsableInstitucional> repository)
        {
            _respository = repository;
        }

        public async Task<ResponsableInstitucional> Obtener()
        {
            try
            {
                IQueryable<ResponsableInstitucional> query = await _respository.Consultar(i => i.ResponsableInstitucionalID == 1);
                ResponsableInstitucional responsable = query.Include(u => u.Universidad).First();
                return responsable;
            }
            catch
            {
                throw;
            }
        }



        public async Task<ResponsableInstitucional> GuardarCambios(ResponsableInstitucional entidad)
        {
            try
            {
                ResponsableInstitucional responsable_encontrado = await _respository.Obtener(i => i.ResponsableInstitucionalID == 1);

                responsable_encontrado.CURP = entidad.CURP;
                responsable_encontrado.NombreR = entidad.NombreR;
                responsable_encontrado.ApellidoP = entidad.ApellidoP;
                responsable_encontrado.ApellidoM = entidad.ApellidoM;
                responsable_encontrado.Correo = entidad.Correo;
                responsable_encontrado.Telefono = entidad.Telefono;
                responsable_encontrado.Cargo = entidad.Cargo;
                responsable_encontrado.UniversidadID = entidad.UniversidadID;

                await _respository.Editar(responsable_encontrado);
                return responsable_encontrado;
            }
            catch
            {
                throw;
            }
        }

        
    }
}

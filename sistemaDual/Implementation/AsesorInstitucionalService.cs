using Microsoft.EntityFrameworkCore;
using sistemaDual.Interfaces;
using sistemaDual.Models;

namespace sistemaDual.Implementation
{
    public class AsesorInstitucionalService : IAsesorInstitucionalService
    {
        private readonly IGenericRespository<AsesorInstitucional> _repository;

        public AsesorInstitucionalService(IGenericRespository<AsesorInstitucional> repository)
        {
            _repository = repository;
        }
        
        public async Task<AsesorInstitucional> Obtener()
        {
            try
            {
                IQueryable<AsesorInstitucional> query = await _repository.Consultar(i => i.AsesorInstitucionalID == 1);
                AsesorInstitucional asesor = query.Include(p => p.ProgramaEducativo).First();
                return asesor;
            }
            catch
            {
                throw;
            }
        }

        public async Task<AsesorInstitucional> GuardarCambios(AsesorInstitucional entidad)
        {
            try
            {
                AsesorInstitucional editar_asesor = await _repository.Obtener(i => i.AsesorInstitucionalID == 1);
                editar_asesor.CURP = entidad.CURP;
                editar_asesor.NombreA = entidad.NombreA;
                editar_asesor.ApellidoP = entidad.ApellidoP;
                editar_asesor.ApellidoM = entidad.ApellidoM;
                editar_asesor.Correo = entidad.Correo;
                editar_asesor.Telefono = entidad.Telefono;
                editar_asesor.ProgramaEducativoID = entidad.ProgramaEducativoID;

                await _repository.Editar(editar_asesor);
                return editar_asesor;
     
            }
            catch
            {
                throw;
            }
        }

        
    }
}

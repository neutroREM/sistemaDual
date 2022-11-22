using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
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

        public async Task<List<AsesorInstitucional>> Lista()
        {
            IQueryable<AsesorInstitucional> query = await _repository.Consultar();
            return query.Include(p => p.ProgramaEducativo).ToList();
        }

        public async Task<AsesorInstitucional> Crear(AsesorInstitucional entidad)
        {
            AsesorInstitucional mentor_existe = await _repository.Obtener(i => i.AsesorInstitucionalID == entidad.AsesorInstitucionalID);
            if (mentor_existe != null)
                throw new TaskCanceledException("Este Mentor ya esta registrado");

            try
            {
                AsesorInstitucional nuevo_mentor = await _repository.Crear(entidad);
                if (entidad.AsesorInstitucionalID == 0)
                    throw new TaskCanceledException("No se puedo registrar el Mentor");

                IQueryable<AsesorInstitucional> query = await _repository.Consultar(i => i.AsesorInstitucionalID == nuevo_mentor.AsesorInstitucionalID);
                nuevo_mentor = query.Include(p => p.ProgramaEducativo).First();
                return nuevo_mentor;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<AsesorInstitucional> GuardarCambios(AsesorInstitucional entidad)
        {
            AsesorInstitucional asesor_existe = await _repository.Obtener(i => i.AsesorInstitucionalID == entidad.AsesorInstitucionalID);
            if (asesor_existe == null)
                throw new TaskCanceledException("Este Mentor ya esta registrado");

            try
            {
                IQueryable<AsesorInstitucional> query = await _repository.Consultar(i => i.AsesorInstitucionalID == entidad.AsesorInstitucionalID);
                AsesorInstitucional editar_asesor = query.First();
                editar_asesor.CURP = entidad.CURP;
                editar_asesor.NombreA = entidad.NombreA;
                editar_asesor.ApellidoP = entidad.ApellidoP;
                editar_asesor.ApellidoM = entidad.ApellidoM;
                editar_asesor.Correo = entidad.Correo;
                editar_asesor.Telefono = entidad.Telefono;
                editar_asesor.ProgramaEducativoID = entidad.ProgramaEducativoID;

                bool resp = await _repository.Editar(editar_asesor);
                if (!resp)
                    throw new TaskCanceledException("No se puedo editar el Mentor");

                AsesorInstitucional asesor_editado = query.Include(p => p.ProgramaEducativo).First();
                return asesor_editado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int asesorInstitucionalID)
        {
            try
            {
                AsesorInstitucional eliminar_asesor = await _repository.Obtener(i => i.AsesorInstitucionalID == asesorInstitucionalID);
                if (eliminar_asesor == null)
                    throw new TaskCanceledException("No esta registrado");

                bool resp = await _repository.Eliminar(eliminar_asesor);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<List<MentorAcademico>> ObtenerAsesor(int asesorInstitucionalID)
        {
            throw new NotImplementedException();
        }
    }
}

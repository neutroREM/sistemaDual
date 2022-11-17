using Microsoft.EntityFrameworkCore;
using sistemaDual.Interfaces;
using sistemaDual.Models;

namespace sistemaDual.Implementation
{
    public class ProgramaEducativoService : IProgramaEducativoService
    {
        private readonly IGenericRespository<ProgramaEducativo> _repository;


        public ProgramaEducativoService(IGenericRespository<ProgramaEducativo> respository)
        {
            _repository = respository;
        }

        public async Task<List<ProgramaEducativo>> Lista()
        {
            IQueryable<ProgramaEducativo> query = await _repository.Consultar();
            return query.Include(u => u.Universidad).ToList();
        }

        public async Task<ProgramaEducativo> Crear(ProgramaEducativo entidad)
        {
            ProgramaEducativo programa_existe = await _repository.Obtener(i => i.ProgramaEducativoID == entidad.ProgramaEducativoID);
            if (programa_existe != null)
                throw new TaskCanceledException("Ya esta este PE");

            try
            {
                ProgramaEducativo nuevo_programa = await _repository.Crear(entidad);
                if (entidad.ProgramaEducativoID == 0)
                    throw new TaskCanceledException("No se puedo registrar el programa");

                IQueryable<ProgramaEducativo> query = await _repository.Consultar(i => i.ProgramaEducativoID == nuevo_programa.ProgramaEducativoID);
                nuevo_programa = query.Include(u => u.Universidad).First();
                return nuevo_programa;
            }
            catch(Exception ex)
            {
                throw;
            }

        }

        public async Task<ProgramaEducativo> Editar(ProgramaEducativo entidad)
        {
            ProgramaEducativo programa_existe = await _repository.Obtener(i => i.ProgramaEducativoID == entidad.ProgramaEducativoID);
            if (programa_existe == null)
                throw new TaskCanceledException("No existe este PE");

            try
            {
                IQueryable<ProgramaEducativo> query = await _repository.Consultar(i => i.ProgramaEducativoID == entidad.ProgramaEducativoID);
                ProgramaEducativo editar_programa = query.First();

                editar_programa.NombreP = entidad.NombreP;
                editar_programa.Version = entidad.Version;
                editar_programa.UniversidadID = entidad.UniversidadID;

                bool resp = await _repository.Editar(editar_programa);
                if (!resp)
                    throw new TaskCanceledException("No se puedo editar el PE");

                ProgramaEducativo programa_editado = query.Include(u => u.Universidad).First();
                return programa_editado;

            }
            catch 
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int programaEducativoID)
        {
            try
            {
                ProgramaEducativo eliminar_programa = await _repository.Obtener(i => i.ProgramaEducativoID == programaEducativoID);

                if (eliminar_programa == null)
                    throw new TaskCanceledException("La UE no existe");

                bool resp = await _repository.Eliminar(eliminar_programa);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProgramaEducativo> Obtener()
        {
            try
            {
                IQueryable<ProgramaEducativo> query = await _repository.Consultar(i => i.ProgramaEducativoID == 1);
                ProgramaEducativo programa = query.Include(u => u.Universidad).First();
                return programa;
            }
            catch
            {
                throw;
            }
        }

        
    }
}

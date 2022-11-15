using sistemaDual.Interfaces;
using sistemaDual.Models;

namespace sistemaDual.Implementation
{
    public class AsignaturaService : IAsignaturaService
    {
        private readonly IGenericRespository<Asignatura> _repository;

        public AsignaturaService(IGenericRespository<Asignatura> repository)
        {
            _repository = repository;
        }

        public async Task<List<Asignatura>> Lista()
        {
            IQueryable<Asignatura> query = await _repository.Consultar();
            return query.ToList();  
        }

        public async Task<Asignatura> Crear(Asignatura entidad)
        {
            Asignatura asignatura_existe = await _repository.Obtener(i => i.AsignaturaID == entidad.AsignaturaID);
            if (asignatura_existe != null)
                throw new TaskCanceledException("Esta Asignatura ya esta registrada");

            try
            {
                Asignatura nueva_asignatura = await _repository.Crear(entidad);
                if (entidad.AsignaturaID == 0)
                    throw new TaskCanceledException("No se puedo registrar la Asignatura");

                IQueryable<Asignatura> query = await _repository.Consultar(i => i.AsignaturaID == nueva_asignatura.AsignaturaID);
                nueva_asignatura = query.First();
                return nueva_asignatura;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Asignatura> Editar(Asignatura entidad)
        {
            Asignatura asignatura_existe = await _repository.Obtener(i => i.AsignaturaID == entidad.AsignaturaID);
            if (asignatura_existe == null)
                throw new TaskCanceledException("Esta Asignatura no esta registrada");

            try
            {
                IQueryable<Asignatura> query = await _repository.Consultar(i => i.AsignaturaID == entidad.AsignaturaID);
                Asignatura editar_asignatura = query.First();
                editar_asignatura.NombreAsignatura = entidad.NombreAsignatura;
                editar_asignatura.Periodo = entidad.Periodo;
                editar_asignatura.Competencia = entidad.Competencia ;
                editar_asignatura.Actividad = entidad.Actividad;

                bool resp = await _repository.Editar(editar_asignatura);
                if (!resp)
                    throw new TaskCanceledException("No se puedo editar la Asignatura");

                Asignatura asignatura_editada = query.First();
                return asignatura_editada;
            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> Eliminar(int asignaturaID)
        {
            try
            {
                Asignatura asignatura_eliminar = await _repository.Obtener(i => i.AsignaturaID == asignaturaID);
                if (asignatura_eliminar == null)
                    throw new TaskCanceledException("No esta registrada la Asignatura");

                bool resp = await _repository.Eliminar(asignatura_eliminar);
                return true;
            }
            catch
            {
                throw;
            }
        }

    }
}

using Microsoft.EntityFrameworkCore;
using sistemaDual.Interfaces;
using sistemaDual.Models;

namespace sistemaDual.Implementation
{
    public class BecaDualService : IBecaDualService
    {
        private readonly IGenericRespository<BecaDual> _repository;

        public BecaDualService(IGenericRespository<BecaDual> repository)
        {
            _repository = repository;
        }

        public async Task<List<BecaDual>> Lista()
        {
            IQueryable<BecaDual> query = await _repository.Consultar();
            return query.ToList();
        }

        public async Task<BecaDual> Crear(BecaDual entidad)
        {
            BecaDual beca_existe = await _repository.Obtener(i => i.BecaDualID == entidad.BecaDualID);
            if (beca_existe != null)
                throw new TaskCanceledException("Esta Beca ya esta registrada");

            try
            {
                BecaDual nueva_beca = await _repository.Crear(entidad);
                if (entidad.BecaDualID == 0)
                    throw new TaskCanceledException("No se pudo registrar la Beca");

                IQueryable<BecaDual> query = await _repository.Consultar(i => i.BecaDualID == nueva_beca.BecaDualID);
                nueva_beca = query.First();
                return nueva_beca;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<BecaDual> Editar(BecaDual entidad)
        {
            BecaDual beca_existe = await _repository.Obtener(i => i.BecaDualID == entidad.BecaDualID);
            if (beca_existe == null)
                throw new TaskCanceledException("Esta Beca no esta registrada");

            try
            {
                IQueryable<BecaDual> query = await _repository.Consultar(i => i.BecaDualID == entidad.BecaDualID);
                BecaDual beca_editar = query.First();
                beca_editar.Fuente = entidad.Fuente;
                beca_editar.TipoBeca = entidad.TipoBeca;
                beca_editar.Periocidad = entidad.Periocidad;
                beca_editar.Duracion = entidad.Duracion;

                bool resp = await _repository.Editar(beca_editar);
                if (!resp)
                    throw new TaskCanceledException("No se pudo editar la Beca");

                BecaDual beca_editada = query.First();
                return beca_editada;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int becaDualID)
        {
            try
            {
                BecaDual beca_eliminar = await _repository.Obtener(i => i.BecaDualID == becaDualID);
                if (beca_eliminar == null)
                    throw new TaskCanceledException("No existe la Beca");

                bool resp = await _repository.Eliminar(beca_eliminar);
                return true;
            }
            catch
            {
                throw;
            }
        }

        
    }
}

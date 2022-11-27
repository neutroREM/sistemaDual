using sistemaDual.Interfaces;
using sistemaDual.Models;

namespace sistemaDual.Implementation
{
    public class EstatusService : IEstatusService
    {
        public readonly IGenericRespository<Estatus> _repository;

        public EstatusService(IGenericRespository<Estatus> repository)
        {
            _repository = repository;
        }

        public async Task<List<Estatus>> Lista()
        {
            IQueryable<Estatus> query = await _repository.Consultar();
            return query.ToList();
        }
    }
}

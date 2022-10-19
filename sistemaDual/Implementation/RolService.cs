using sistemaDual.Interfaces;
using sistemaDual.Models;

namespace sistemaDual.Implementation
{
    public class RolService : IRolService
    {
        private readonly IGenericRespository<Rol> _repository;

        public RolService(IGenericRespository<Rol> repository)
        {
                _repository = repository;
        }

        public async Task<List<Rol>> Lista()
        {
            IQueryable<Rol> query = await _repository.Consultar();
            return query.ToList();  
        }
    }
}

using Microsoft.EntityFrameworkCore;
using sistemaDual.Interfaces;
using sistemaDual.Models;

namespace sistemaDual.Implementation
{
    public class DomicilioService : IDomicilioService
    {
        private readonly IGenericRespository<Domicilio> _repository;

        public DomicilioService(IGenericRespository<Domicilio> repository)
        {
            _repository = repository;
        }

        public Task<Domicilio> Crear()
        {
            throw new NotImplementedException();
        }

        public Task<Domicilio> Editar()
        {
            throw new NotImplementedException();
        }

    }
}

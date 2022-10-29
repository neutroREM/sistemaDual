using sistemaDual.Models;

namespace sistemaDual.Interfaces
{
    public interface IDomicilioService
    {
        Task<Domicilio> Crear();

        Task<Domicilio> Editar();

    }
}

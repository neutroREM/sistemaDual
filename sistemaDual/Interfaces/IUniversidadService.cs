using sistemaDual.Models;

namespace sistemaDual.Interfaces
{
    public interface IUniversidadService
    {
        Task<List<Universidad>> Lista();

        Task<Universidad> Crear(Universidad entidad);

        Task<Universidad> Editar(Universidad entidad);

        Task<Universidad> Obtener();
    }
}

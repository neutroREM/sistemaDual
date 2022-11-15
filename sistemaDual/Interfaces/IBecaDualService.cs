using sistemaDual.Models;

namespace sistemaDual.Interfaces
{
    public interface IBecaDualService
    {
        Task<List<BecaDual>> Lista();

        Task<BecaDual> Crear(BecaDual entidad);

        Task<BecaDual> Editar(BecaDual entidad);

        Task<bool> Eliminar(int becaDualID);
    }
}

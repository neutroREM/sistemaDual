using sistemaDual.Models;

namespace sistemaDual.Interfaces
{
    public interface IRolService
    {
        Task<List<Rol>> Lista();
    }
}

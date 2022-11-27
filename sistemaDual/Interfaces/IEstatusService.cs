using sistemaDual.Models;

namespace sistemaDual.Interfaces
{
    public interface IEstatusService
    {
        Task<List<Estatus>> Lista();
    }
}

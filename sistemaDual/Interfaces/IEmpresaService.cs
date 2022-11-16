using sistemaDual.Models;

namespace sistemaDual.Interfaces
{
    public interface IEmpresaService
    {
        Task<List<Empresa>> Lista();

        Task<Empresa> Crear(Empresa modelo);

        Task<Empresa> Editar(Empresa modelo);

        Task<bool> Eliminar(int EmpresaID);

        Task<Empresa> ObtenerXRFC(int EmpresaID);
    }
}

using sistemaDual.Models;

namespace sistemaDual.Interfaces
{
    public interface IEmpresaService
    {
        Task<List<Empresa>> Lista();

        Task<Empresa> Crear(Empresa modelo);

        Task<Empresa> Editar(Empresa modelo);

        Task<bool> Eliminar(string EmpresaID);

        Task<Empresa> ObtenerXRFC(string EmpresaID);
    }
}

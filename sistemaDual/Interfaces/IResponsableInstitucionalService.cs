using sistemaDual.Models;

namespace sistemaDual.Interfaces
{
    public interface IResponsableInstitucionalService
    {
        Task<List<ResponsableInstitucional>> Lista();

        Task<ResponsableInstitucional> Crear(ResponsableInstitucional entidad);

        Task<ResponsableInstitucional> GuardarCambios(ResponsableInstitucional entidad);

        Task<bool> Eliminar(int responsablesInstitucionalID);
    }
}

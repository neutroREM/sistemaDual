using sistemaDual.Models;

namespace sistemaDual.Interfaces
{
    public interface IResponsableInstitucionalService
    {
        Task<ResponsableInstitucional> Obtener();

        Task<ResponsableInstitucional> GuardarCambios(ResponsableInstitucional entidad);
    }
}

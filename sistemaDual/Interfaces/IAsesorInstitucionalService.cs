using sistemaDual.Models;

namespace sistemaDual.Interfaces
{
    public interface IAsesorInstitucionalService
    {
        Task<AsesorInstitucional> Obtener();

        Task<AsesorInstitucional> GuardarCambios(AsesorInstitucional entidad);

        
    }
}

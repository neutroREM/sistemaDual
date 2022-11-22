using sistemaDual.Models;

namespace sistemaDual.Interfaces
{
    public interface IAsesorInstitucionalService
    {
        Task<List<AsesorInstitucional>> Lista();

        Task<AsesorInstitucional> Crear(AsesorInstitucional entidad);

        Task<AsesorInstitucional> GuardarCambios(AsesorInstitucional entidad);

        Task<bool> Eliminar(int asesorInstitucionalID);

        Task<List<MentorAcademico>> ObtenerAsesor(int asesorInstitucionalID);

    }
}

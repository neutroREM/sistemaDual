using sistemaDual.Models;

namespace sistemaDual.Interfaces
{
    public interface IMentorAcademicoService
    {
        Task<List<MentorAcademico>> Lista();

        Task<MentorAcademico> Crear(MentorAcademico entidad);

        Task<MentorAcademico> Editar(MentorAcademico entidad);

        Task<bool> Eliminar(int mentorAcademicoID);
    }
}

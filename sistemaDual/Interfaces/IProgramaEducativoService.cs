using sistemaDual.Models;

namespace sistemaDual.Interfaces
{
    public interface IProgramaEducativoService
    {
        Task<List<ProgramaEducativo>> Lista();

        Task<ProgramaEducativo> Crear(ProgramaEducativo entidad);

        Task<ProgramaEducativo> Editar(ProgramaEducativo entidad);

        Task<bool> Eliminar(int programaEducativoID);

    }
}

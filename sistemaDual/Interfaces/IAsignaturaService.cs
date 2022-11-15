using sistemaDual.Models;

namespace sistemaDual.Interfaces
{
    public interface IAsignaturaService
    {
        Task<List<Asignatura>> Lista();

        Task<Asignatura> Crear(Asignatura entidad);

        Task<Asignatura> Editar(Asignatura entidad);

        Task<bool> Eliminar(int asignaturaID);
    }
}

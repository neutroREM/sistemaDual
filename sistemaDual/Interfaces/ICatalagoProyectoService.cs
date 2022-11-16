using sistemaDual.Models;

namespace sistemaDual.Interfaces
{
    public interface ICatalagoProyectoService
    {
        Task<List<AlumnoDual>> ObtenerAlumnos(string busqueda);

        Task<List<Empresa>> ObtenerEmpresas(string busqueda);

        Task<CatalagoProyecto> Registrar(CatalagoProyecto entidad);

        Task<List<CatalagoProyecto>> Historial(string numeroProyecto, string fechaInicio, string fechaFin);

        Task<CatalagoProyecto> Detalle(string numeroProyecto);

        Task<List<CatalagoProyecto>> Reporte(string fechaInicio, string fechaFin);
    }
}

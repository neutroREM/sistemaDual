using sistemaDual.Models;
namespace sistemaDual.Interfaces
{
    public interface ICatalagoProyectoRepository : IGenericRespository<CatalagoProyecto>
    {
        Task<CatalagoProyecto> Registrar(CatalagoProyecto entididad);
        
        Task<List<CatalagoProyecto>> Reporte(DateTime fechaInicio, DateTime fechaFin); 
    }
}

using sistemaDual.Data;
using sistemaDual.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using sistemaDual.Models;

namespace sistemaDual.Implementation
{
    public class CatalagoProyectoRepository : GenericRepository<CatalagoProyecto>, ICatalagoProyectoRepository
    {
        private readonly ProgramaDualContext _context;

        public CatalagoProyectoRepository(ProgramaDualContext context) : base(context)
        {
            _context = context;
        }

       
        public Task<CatalagoProyecto> Registrar(CatalagoProyecto entidad)
        {
            
            throw new NotImplementedException();

        }

        public async Task<List<CatalagoProyecto>> Reporte(DateTime fechaInicio, DateTime fechaFin)
        {
            List<CatalagoProyecto> reporteProyecto = await _context.CatalagoProyectos
                .Include(v => v.AlumnoDual)
                .ThenInclude(u => u.ProgramaEducativo)
                .Include(v => v.Empresa)
                .ToListAsync();

            return reporteProyecto;
                
        }
    }
}

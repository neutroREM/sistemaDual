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


        public async Task<CatalagoProyecto> Registrar(CatalagoProyecto entidad)
        {
            
            CatalagoProyecto proyectoGenerado = new CatalagoProyecto();

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    NumeroCorrelativo correlativo = _context.NumerosCorrelativos.Where(n => n.Gestion == "proyecto").First();
                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    correlativo.FechaActualizacion = DateTime.Now;

                    _context.NumerosCorrelativos.Update(correlativo);
                    await _context.SaveChangesAsync();

                    string ceros = string.Concat(Enumerable.Repeat("0", correlativo.CantidadDigitos.Value));
                    string numeroProyecto = ceros + correlativo.UltimoNumero.ToString();
                    numeroProyecto = numeroProyecto.Substring(numeroProyecto.Length - correlativo.CantidadDigitos.Value, correlativo.CantidadDigitos.Value);
                    entidad.FechaRegistro = DateTime.Now;
                    entidad.NumeroProyecto = numeroProyecto;

                    await _context.AddAsync(entidad);
                    await _context.SaveChangesAsync();

                    proyectoGenerado = entidad;

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            return proyectoGenerado;

        }

        public async Task<List<CatalagoProyecto>> Reporte(DateTime fechaInicio, DateTime fechaFin)
        {
            List<CatalagoProyecto> reporteProyecto = await _context.CatalagoProyectos
                .Include(a => a.AlumnoDual)
                .Include(p => p.ProgramaEducativo)
                .Include(e => e.Empresa)
                .Where(cp => cp.FechaRegistro.Value.Date >= fechaInicio.Date &&
                cp.FechaRegistro <= fechaFin.Date).ToListAsync();
                
            return reporteProyecto;
                
        }
    }
}

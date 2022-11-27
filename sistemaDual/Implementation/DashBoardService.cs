using Microsoft.EntityFrameworkCore;
using sistemaDual.Interfaces;
using sistemaDual.Models;

namespace sistemaDual.Implementation
{
    public class DashBoardService : IDashBoardService
    {
        private readonly ICatalagoProyectoRepository _proyectoRepository;
        private readonly IGenericRespository <CatalagoProyecto>  _proyectoGenericRepository;
        private readonly IGenericRespository<AlumnoDual> _alumnoRepository;
        private readonly IGenericRespository<Empresa> _empresaRepository;
        private readonly IGenericRespository<ProgramaEducativo> _programaRepository;
        private DateTime FechaInicioMes = DateTime.Now;
        private DateTime FechaInicioSemana = DateTime.Now;

        public DashBoardService(ICatalagoProyectoRepository _proyectoReposiroty, IGenericRespository<CatalagoProyecto> proyectoGenericRepository, IGenericRespository<AlumnoDual> alumnoRepository, IGenericRespository<Empresa> empresaRepository, IGenericRespository<ProgramaEducativo> programaRepository)
        {
            _proyectoRepository = _proyectoReposiroty;
            _proyectoGenericRepository = proyectoGenericRepository;
            _alumnoRepository = alumnoRepository;
            _empresaRepository = empresaRepository;
            _programaRepository = programaRepository;

            FechaInicioMes = FechaInicioMes.AddMonths(-1);
            FechaInicioSemana = FechaInicioSemana.AddDays(-7);
        }

        public async Task<int> TotalProyectosUltimoMes()
        {
            try
            {
                IQueryable<CatalagoProyecto> query = await _proyectoRepository.Consultar(p => p.FechaRegistro.Value.Date >= FechaInicioMes.Date);
                int total = query.Count();
                return total;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> TotalAlumnosUtimaSemana()
        {
            try
            {
                IQueryable<AlumnoDual> query = await _alumnoRepository.Consultar(a => a.FechaRegistro >= FechaInicioSemana.Date);
                int total = query.Count();
                return total;
            }
            catch
            {
                throw;
            }
           
        }

        public async Task<int> TotalProgramasEducativos()
        {
            try
            {
                IQueryable<ProgramaEducativo> query = await _programaRepository.Consultar();
                int total = query.Count();
                return total;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> TotalEmpresas()
        {
            try
            {
                IQueryable<Empresa> query = await _empresaRepository.Consultar();
                int total = query.Count();
                return total;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Dictionary<string, int>> ProyectoUltimoMes()
        {
            try
            {
                IQueryable<CatalagoProyecto> query = await _proyectoRepository.Consultar(p => p.FechaRegistro.Value.Date >= FechaInicioMes.Date);

                Dictionary<string, int> result = query
                    .Include(a => a.AlumnoDual)
                    .GroupBy(v => v.FechaRegistro.Value.Date)
                    .OrderByDescending(g => g.Key)
                    .Select(cp => new {fecha = cp.Key.ToString("dd/MM/yyyy"), total = cp.Count()})
                    .ToDictionary(keySelector: r => r.fecha, elementSelector: r => r.total);

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Dictionary<string, int>> AlumnosUltimaSemana()
        {
            try
            {
                IQueryable<CatalagoProyecto> query = await _proyectoRepository.Consultar();

                Dictionary<string, int> result = query
                    .Include(a => a.AlumnoDual)
                    .Where(cp => cp.AlumnoDual.FechaRegistro.Value.Date >= FechaInicioSemana.Date)
                    .GroupBy(cp => cp.NumeroProyecto).OrderByDescending(g => g.Count())
                    .Select(cp => new { alumno = cp.Key, total = cp.Count() })
                    .ToDictionary(keySelector: r => r.alumno, elementSelector: r => r.total);

                return result;
            }
            catch
            {
                throw;
            }
        }

        
    }
}

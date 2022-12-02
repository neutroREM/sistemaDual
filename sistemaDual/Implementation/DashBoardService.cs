using Microsoft.EntityFrameworkCore;
using sistemaDual.Interfaces;
using sistemaDual.Models;

namespace sistemaDual.Implementation
{
    public class DashBoardService : IDashBoardService
    {
        private readonly ICatalagoProyectoRepository _proyectoRepository; 
        private readonly IGenericRespository<AlumnoDual> _alumnoRepository;
        private readonly IGenericRespository<Empresa> _empresaRepository;
        private readonly IGenericRespository<ProgramaEducativo> _programaRepository;
        private DateTime FechaInicioSemana = DateTime.Now;

        public DashBoardService(ICatalagoProyectoRepository proyectoReposiroty, IGenericRespository<AlumnoDual> alumnoRepository, IGenericRespository<Empresa> empresaRepository, IGenericRespository<ProgramaEducativo> programaRepository)
        {
            _proyectoRepository = proyectoReposiroty;
            _alumnoRepository = alumnoRepository;
            _empresaRepository = empresaRepository;
            _programaRepository = programaRepository;

            FechaInicioSemana = FechaInicioSemana.AddDays(-7);
        }

        public async Task<int> TotalProyectosUltimaSemana()
        {
            try
            {
                IQueryable<CatalagoProyecto> query = await _proyectoRepository.Consultar();
                int total = query.Count();
                return total;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> TotalAlumnosUltimaSemana()
        {
            try
            {
                IQueryable<AlumnoDual> query = await _alumnoRepository.Consultar();
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

        public async Task<Dictionary<string, int>> ProyectosUltimaSemana()
        {
            try
            {
                IQueryable<CatalagoProyecto> query = await _proyectoRepository.Consultar(p => p.FechaRegistro.Value.Date >= FechaInicioSemana.Date);

                Dictionary<string, int> result = query
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
                    .GroupBy(cp => cp.AlumnoDual.NombreA).OrderByDescending(g => g.Count())
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

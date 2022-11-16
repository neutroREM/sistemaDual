using Microsoft.EntityFrameworkCore;
using sistemaDual.Interfaces;
using sistemaDual.Models;
using System.Globalization;

namespace sistemaDual.Implementation
{
    public class CatalagoProyectoService : ICatalagoProyectoService
    {
        private readonly IGenericRespository<AlumnoDual> _alumnoRepository;
        private readonly IGenericRespository<Empresa> _empresaRepository;
        private readonly ICatalagoProyectoRepository _proyectoRepository;

        public CatalagoProyectoService(IGenericRespository<AlumnoDual> alumnoRepository, IGenericRespository<Empresa> empresaRepository, ICatalagoProyectoRepository proyectoRepository)
        {
            _alumnoRepository = alumnoRepository; 
            _empresaRepository = empresaRepository;
            _proyectoRepository = proyectoRepository;
        }

        public async Task<List<AlumnoDual>> ObtenerAlumnos(string busqueda)
        {
            IQueryable<AlumnoDual> query = await _alumnoRepository.Consultar(
                a => a.EsActivo == true && string.Concat(a.AlumnoDualID, a.NombreA, a.ApellidoP)
                .Contains(busqueda));

            return query.Include(p => p.ProgramaEducativo).ToList();
        }

        public async Task<List<Empresa>> ObtenerEmpresas(string busqueda)
        {
            IQueryable<Empresa> query = await _empresaRepository.Consultar(
                e => e.EsActivo == true && string.Concat(e.NombreC, e.RazonS, e.RepresentanteL)
                .Contains(busqueda));

            return query.ToList();
        }

        public async Task<CatalagoProyecto> Registrar(CatalagoProyecto entidad)
        {
            try
            {
                return await _proyectoRepository.Registrar(entidad);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CatalagoProyecto>> Historial(string numeroProyecto, string fechaInicio, string fechaFin)
        {
            IQueryable<CatalagoProyecto> query = await _proyectoRepository.Consultar();
            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaFin is null ? "" : fechaFin;

            if (fechaInicio != "" && fechaFin != "")
            {
                DateTime fecha_inicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", new CultureInfo("es-MX"));
                DateTime fecha_fin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", new CultureInfo("es-MX"));

                return query.Where(v => v.FechaRegistro.Value.Date >= fecha_inicio.Date && v.FechaRegistro.Value.Date <= fecha_fin.Date)
                    .Include(ad => ad.AlumnoDual)
                    .Include(pe => pe.ProgramaEducativo)
                    .Include(ue => ue.Empresa)
                    .ToList();
            }
            else
            {
                return query.Where(v => v.NumeroProyecto == numeroProyecto)
                   .Include(ad => ad.AlumnoDual)
                   .Include(pe => pe.ProgramaEducativo)
                   .Include(ue => ue.Empresa)
                   .ToList();
            }
        }

        public async Task<CatalagoProyecto> Detalle(string numeroProyecto)
        {
            IQueryable<CatalagoProyecto> query = await _proyectoRepository.Consultar(cp => cp.NumeroProyecto == numeroProyecto);
            return query
                    .Include(ad => ad.AlumnoDual)
                    .Include(pe => pe.ProgramaEducativo)
                    .Include(e => e.Empresa)
                    .First();
                
        }


        public async Task<List<CatalagoProyecto>> Reporte(string fechaInicio, string fechaFin)
        {
            DateTime fecha_inicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", new CultureInfo("es-MX"));
            DateTime fecha_fin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", new CultureInfo("es-MX"));

            List<CatalagoProyecto> lista = await _proyectoRepository.Reporte(fecha_inicio, fecha_fin);
            return lista;
        }
    }
}

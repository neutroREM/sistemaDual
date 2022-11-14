using Microsoft.EntityFrameworkCore;
using sistemaDual.Interfaces;
using sistemaDual.Models;

namespace sistemaDual.Implementation
{
    public class UniversidadService : IUniversidadService
    {
        private readonly IGenericRespository<Universidad> _repository;

        public UniversidadService(IGenericRespository<Universidad> repository)
        {
            _repository = repository;
        }

        public async Task<List<Universidad>> Lista()
        {
            IQueryable<Universidad> query = await _repository.Consultar();
            return query.Include(d => d.Domicilio).ToList();
        }

        public async Task<Universidad> Crear(Universidad entidad)
        {
            Universidad universidad_existe = await _repository.Obtener(i => i.UniversidadID == entidad.UniversidadID);
            if (universidad_existe != null)
                throw new TaskCanceledException("Esta univesidad ya esta registrada");

            try
            {
                entidad.FechaRegistro = DateTime.Now;
                Universidad nueva_uni = await _repository.Crear(entidad);
                if(entidad.UniversidadID == null)
                    throw new TaskCanceledException("No se puedo registrar la Universidad");

                IQueryable<Universidad> query = await _repository.Consultar(i => i.UniversidadID == nueva_uni.UniversidadID);
                nueva_uni = query.Include(d => d.Domicilio).First();
                return nueva_uni;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<Universidad> Editar(Universidad entidad)
        {
            try
            {
                Universidad uni_editar = await _repository.Obtener(i => i.UniversidadID == "15EPO0003Y");
                uni_editar.NombreU = entidad.NombreU;
                uni_editar.FechaCambio = DateTime.Now;

                await _repository.Editar(uni_editar);
                return uni_editar;
               
            }
            catch
            {
                throw;
            }
        }



        public async Task<Universidad> Obtener()
        {
            try
            {

                IQueryable<Universidad> query = await _repository.Consultar(i => i.UniversidadID == "15EPO0003Y");
                Universidad uni_encontrada = query.Include(d => d.Domicilio).First();
                return uni_encontrada;
            }
            catch
            {
                throw;
            }

        }
    }
}

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
            Universidad universidad_existe = await _repository.Obtener(i => i.UniversidadID == entidad.UniversidadID);
            if (universidad_existe != null)
                throw new TaskCanceledException("Esta univesidad ya esta registrada");

            try
            {
                IQueryable<Universidad> query = await _repository.Consultar(u => u.UniversidadID == entidad.UniversidadID);
                Universidad uni_editar = query.First();

                uni_editar.UniversidadID = entidad.UniversidadID;
                uni_editar.NombreU = entidad.NombreU;
                uni_editar.FechaCambio = DateTime.Now;
                uni_editar.DomicilioID = entidad.DomicilioID;
                uni_editar.Domicilio.Direccion = entidad.Domicilio.Direccion;
                uni_editar.Domicilio.Colonia = entidad.Domicilio.Colonia;
                uni_editar.Domicilio.Municipio = entidad.Domicilio.Municipio;
                uni_editar.Domicilio.CodigoPostal = entidad.Domicilio.CodigoPostal;
                uni_editar.Domicilio.Otros = entidad.Domicilio.Otros;

                
 
                bool resp = await _repository.Editar(uni_editar);
                if (!resp)
                    throw new TaskCanceledException("No se pudo registrar");

                Universidad uni_editada = query.Include(d => d.Domicilio).First();
                return uni_editada;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(string UniversidadID)
        {
            try
            {
                Universidad uni_eliminar = await _repository.Obtener(id => id.UniversidadID == UniversidadID);

                if (uni_eliminar == null)
                    throw new TaskCanceledException("La UE no existe");

                bool resp = await _repository.Eliminar(uni_eliminar);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Universidad> ObtenerXCCT(string UniversidadID)
        {
            IQueryable<Universidad> query = await _repository.Consultar(i => i.UniversidadID == UniversidadID);
            Universidad result = query.Include(d => d.Domicilio).FirstOrDefault();
            return result;
        }
    }
}

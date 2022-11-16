using Microsoft.EntityFrameworkCore;
using sistemaDual.Interfaces;
using sistemaDual.Models;

namespace sistemaDual.Implementation
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IGenericRespository<Empresa> _repository;

        public EmpresaService(IGenericRespository<Empresa> repository)
        {
            _repository = repository;
        }

        public async Task<List<Empresa>> Lista()
        {
            IQueryable<Empresa> query = await _repository.Consultar();
            return query.ToList();
        }

        public async Task<Empresa> Crear(Empresa modelo)
        {
            Empresa empresa_existe = await _repository.Obtener(u => u.EmpresaID == modelo.EmpresaID);
            if(empresa_existe != null)
                throw new TaskCanceledException("Esta UE ya esta registrada");

            try
            {
                modelo.FechaRegistro = DateTime.Now;
                Empresa nueva_empresa = await _repository.Crear(modelo);
                if (nueva_empresa.EmpresaID == null)
                    throw new TaskCanceledException("No se pudo registrar a la UE");

                IQueryable<Empresa> query = await _repository.Consultar(u => u.EmpresaID == nueva_empresa.EmpresaID);
                nueva_empresa = query.First();
                return nueva_empresa;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Empresa> Editar(Empresa modelo)
        {
            try
            {
                IQueryable<Empresa> query = await _repository.Consultar(i => i.EmpresaID == modelo.EmpresaID);
                Empresa empresa_editar = query.First();

                empresa_editar.EmpresaID = modelo.EmpresaID;
                empresa_editar.RazonS = modelo.RazonS;
                empresa_editar.NombreC = modelo.NombreC;
                empresa_editar.SectorS = modelo.SectorS;
                empresa_editar.RepresentanteL = modelo.RepresentanteL;
                empresa_editar.CorreoR = modelo.CorreoR;
                empresa_editar.FechaCambio = DateTime.Now;
                
               

               

                bool resp = await _repository.Editar(empresa_editar);

                if (!resp) 
                    throw new TaskCanceledException("No se pudo registrar");

                //Empresa empresa_editada = query.Include(d => d.Domicilio).First();
                return empresa_editar;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int EmpresaID)
        {
            try
            {
                Empresa empresa_eliminar = await _repository.Obtener(id => id.EmpresaID == EmpresaID);

                if (empresa_eliminar == null)
                    throw new TaskCanceledException("La UE no existe");

                bool resp = await _repository.Eliminar(empresa_eliminar);
                return true;
            }catch
            {
                throw;
            }
        }

        public async Task<Empresa> ObtenerXRFC(int EmpresaID)
        {
            IQueryable<Empresa> query = await _repository.Consultar(i => i.EmpresaID == EmpresaID);
            Empresa result = query.First();
            return result;
        }
    }
}

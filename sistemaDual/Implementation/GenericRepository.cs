using sistemaDual.Data;
using sistemaDual.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace sistemaDual.Implementation
{
    public class GenericRepository<TEntity> : IGenericRespository<TEntity> where TEntity : class
    {
        private readonly ProgramaDualContext _context;

        public GenericRepository(ProgramaDualContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Obtener(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                TEntity entity = await _context.Set<TEntity>().FirstAsync(filter);
                return entity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TEntity> Crear(TEntity entidad)
        {
            try
            {
                _context.Set<TEntity>().Add(entidad);
                await _context.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(TEntity entidad)
        {
            try
            {
                _context.Update(entidad);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(TEntity entidad)
        {
            try
            {
                _context.Remove(entidad);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IQueryable<TEntity>> Consultar(Expression<Func<TEntity, bool>> filter = null)
        {
            
            IQueryable<TEntity> query = filter == null ? _context.Set<TEntity>() :
                _context.Set<TEntity>().Where(filter)  ;
            
            return  query;
        }
    }
}

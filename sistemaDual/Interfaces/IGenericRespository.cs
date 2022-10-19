using System.Linq.Expressions;

namespace sistemaDual.Interfaces
{
    public interface IGenericRespository<TEntity> where TEntity : class
    {
        Task<TEntity> Obtener(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> Crear(TEntity entidad);

        Task<bool> Editar(TEntity entidad);

        Task<bool> Eliminar(TEntity entidad);

        Task<IQueryable<TEntity>> Consultar(Expression<Func<TEntity, bool>> filter = null);
 
    }
}

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CoreNative.Base.Entites;

namespace CoreNative.Base.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<IQueryable<T>> GetListAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}

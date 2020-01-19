using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CoreNative.Base.Entites;
using Microsoft.EntityFrameworkCore;

namespace CoreNative.Base.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        private readonly DbContext _context;

        protected EfEntityRepositoryBase()
        {
            _context = new TContext();
        }

        public async Task<IQueryable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await
                Task.Run(() => filter == null
                 ? _context.Set<TEntity>().AsNoTracking()
                 : _context.Set<TEntity>().Where(filter).AsNoTracking());
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .SingleOrDefaultAsync(filter);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}

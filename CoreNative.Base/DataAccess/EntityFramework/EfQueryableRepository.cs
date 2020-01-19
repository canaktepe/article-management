using System.Linq;
using CoreNative.Base.Entites;
using Microsoft.EntityFrameworkCore;

namespace CoreNative.Base.DataAccess.EntityFramework
{
    public sealed class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _context;
        private DbSet<T> _entities;

        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => this.Entities;

        private DbSet<T> Entities
        {
            get { return _entities ??= _context.Set<T>(); }
        }
    }
}

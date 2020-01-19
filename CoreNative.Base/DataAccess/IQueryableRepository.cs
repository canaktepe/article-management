using System.Linq;
using CoreNative.Base.Entites;

namespace CoreNative.Base.DataAccess
{
    public interface IQueryableRepository<out T> where T : class, IEntity, new()
    {
        IQueryable<T> Table { get; }
    }
}

using CoreNative.ArticleManagement.Entities.Concrete;
using CoreNative.Base.DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace CoreNative.ArticleManagement.DataAccess.Abstract
{
    public interface IArticleDal : IEntityRepository<Article>
    {
        Task<IQueryable<Article>> SearchArticlesByKeyword(string keyword);
    }
}

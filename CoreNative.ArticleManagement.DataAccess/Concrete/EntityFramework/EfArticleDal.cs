using System.Linq;
using System.Threading.Tasks;
using CoreNative.ArticleManagement.Entities.Concrete;
using CoreNative.Base.DataAccess.EntityFramework;
using CoreNative.ArticleManagement.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CoreNative.ArticleManagement.DataAccess.Concrete.EntityFramework
{
    public class EfArticleDal : EfEntityRepositoryBase<Article, ArticleAppContext>, IArticleDal
    {
        readonly ArticleAppContext _context;
        public EfArticleDal()
        {
            _context = new ArticleAppContext();
        }

        public async Task<IQueryable<Article>> SearchArticlesByKeyword(string keyword)
        {
            keyword = keyword.ToLower();
            return await Task.Run(() => _context.Articles.Where(a => a.Title.ToLower().Contains(keyword) || a.Summary.ToLower().Contains(keyword) || a.Content.ToLower().Contains(keyword)));
        }
    }
}

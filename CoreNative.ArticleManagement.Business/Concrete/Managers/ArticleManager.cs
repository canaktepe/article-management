using System.Linq;
using System.Threading.Tasks;
using CoreNative.ArticleManagement.Business.Abstract;
using CoreNative.ArticleManagement.DataAccess.Abstract;
using CoreNative.ArticleManagement.Entities.Concrete;

namespace CoreNative.ArticleManagement.Business.Concrete.Managers
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public Task<IQueryable<Article>> GetAllAsync()
        {
            return _articleDal.GetListAsync();
        }

        public Task<Article> GetByIdAsync(int id)
        {
            return _articleDal.GetAsync(w => w.ArticleId == id);
        }

        public Task<Article> AddAsync(Article article)
        {
            return _articleDal.AddAsync(article);
        }

        public Task UpdateAsync(Article article)
        {
            return _articleDal.UpdateAsync(article);
        }

        public Task DeleteAsync(Article article)
        {
            return _articleDal.DeleteAsync(article);
        }

        public Task<IQueryable<Article>> SearchArticlesByKeyword(string keyword)
        {
            return _articleDal.SearchArticlesByKeyword(keyword);
        }
    }
}

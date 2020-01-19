using System.Linq;
using System.Threading.Tasks;
using CoreNative.ArticleManagement.Entities.Concrete;
using CoreNative.ArticleManagement.Business.Abstract;
using CoreNative.ArticleManagement.DataAccess.Abstract;

namespace CoreNative.ArticleManagement.Business.Concrete.Managers
{
    public class ArticleCommentManager : IArticleCommentService
    {
        private readonly IArticleCommentDal _articleCommentDal;

        public ArticleCommentManager(IArticleCommentDal articleCommentDal)
        {
            _articleCommentDal = articleCommentDal;
        }

        public Task<IQueryable<ArticleComment>> GetAllAsync()
        {
            return _articleCommentDal.GetListAsync();
        }

        public Task<ArticleComment> GetByIdAsync(int id)
        {
            return _articleCommentDal.GetAsync(w => w.ArticleId == id);
        }

        public Task<ArticleComment> AddAsync(ArticleComment articleComment)
        {
            return _articleCommentDal.AddAsync(articleComment);
        }

        public Task UpdateAsync(ArticleComment articleComment)
        {
            return _articleCommentDal.UpdateAsync(articleComment);
        }

        public Task DeleteAsync(ArticleComment articleComment)
        {
            return _articleCommentDal.DeleteAsync(articleComment);
        }
    }
}

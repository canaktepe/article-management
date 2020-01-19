using CoreNative.ArticleManagement.Entities.Concrete;
using System.Linq;
using System.Threading.Tasks;
namespace CoreNative.ArticleManagement.Business.Abstract
{
    public interface IArticleCommentService
    {
        Task<IQueryable<ArticleComment>> GetAllAsync();
        Task<ArticleComment> GetByIdAsync(int id);
        Task<ArticleComment> AddAsync(ArticleComment articleComment);
        Task UpdateAsync(ArticleComment articleComment);
        Task DeleteAsync(ArticleComment articleComment);
    }
}

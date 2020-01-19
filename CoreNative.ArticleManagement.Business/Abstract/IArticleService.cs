using CoreNative.ArticleManagement.Entities.Concrete;
using System.Linq;
using System.Threading.Tasks;
namespace CoreNative.ArticleManagement.Business.Abstract
{
    public interface IArticleService
    {
        Task<IQueryable<Article>> GetAllAsync();
        Task<Article> GetByIdAsync(int id);
        Task<Article> AddAsync(Article article);
        Task UpdateAsync(Article article);
        Task DeleteAsync(Article article);
        Task<IQueryable<Article>> SearchArticlesByKeyword(string keyword);
    }
}

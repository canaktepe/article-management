using CoreNative.ArticleManagement.Entities.Concrete;
using CoreNative.Base.DataAccess;
namespace CoreNative.ArticleManagement.DataAccess.Abstract
{
    public interface IArticleCommentDal : IEntityRepository<ArticleComment>
    {
    }
}

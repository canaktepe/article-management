using CoreNative.ArticleManagement.Entities.Concrete;
using CoreNative.Base.DataAccess.EntityFramework;
using CoreNative.ArticleManagement.DataAccess.Abstract;

namespace CoreNative.ArticleManagement.DataAccess.Concrete.EntityFramework
{
    public class EfArticleCommentDal : EfEntityRepositoryBase<ArticleComment, ArticleAppContext>, IArticleCommentDal
    {
    }
}

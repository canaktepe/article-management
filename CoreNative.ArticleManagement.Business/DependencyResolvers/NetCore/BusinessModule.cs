using CoreNative.Base.DataAccess;
using CoreNative.Base.DataAccess.EntityFramework;
using CoreNative.ArticleManagement.Business.Abstract;
using CoreNative.ArticleManagement.Business.Concrete.Managers;
using CoreNative.ArticleManagement.DataAccess.Abstract;
using CoreNative.ArticleManagement.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoreNative.ArticleManagement.Business.DependencyResolvers.NetCore
{
    public static class BusinessModule
    {
        public static void UseBusinessModule(this IServiceCollection services)
        {
            services.AddScoped<IArticleService, ArticleManager>();
            services.AddScoped<IArticleCommentService, ArticleCommentManager>();

            services.AddScoped<IArticleDal, EfArticleDal>();
            services.AddScoped<IArticleCommentDal, EfArticleCommentDal>();

            services.AddScoped(typeof(IQueryableRepository<>), typeof(EfQueryableRepository<>));
            services.AddScoped(typeof(DbContext), typeof(ArticleAppContext));
        }
    }
}

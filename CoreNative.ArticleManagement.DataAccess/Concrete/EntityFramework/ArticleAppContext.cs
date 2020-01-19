using CoreNative.ArticleManagement.Entities.Concrete;
using CoreNative.ArticleManagement.DataAccess.Concrete.EntityFramework.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoreNative.ArticleManagement.DataAccess.Concrete.EntityFramework
{
    public class ArticleAppContext : DbContext
    {
        public ArticleAppContext()
        {
        }

        public ArticleAppContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleComment> ArticleComments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var config = builder.Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString(nameof(ArticleAppContext)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleMap());
            modelBuilder.ApplyConfiguration(new Mappings.ArticleCommentMap());
        }
    }
}

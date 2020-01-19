using CoreNative.ArticleManagement.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreNative.ArticleManagement.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable(@"Articles", @"dbo");
            builder.HasKey(x => x.ArticleId );
            builder.Property(x => x.Title).HasColumnName("Title");
            builder.Property(x => x.Summary).HasColumnName("Summary");
            builder.Property(x => x.Content).HasColumnName("Content");
            builder.Property(x => x.Thumbnail).HasColumnName("Thumbnail");
            builder.Property(x => x.Author).HasColumnName("Author");
            builder.Property(x => x.CreateDate).HasColumnName("CreateDate");
            builder.Property(x => x.Status).HasColumnName("Status");
        }
    }
}

using CoreNative.ArticleManagement.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreNative.ArticleManagement.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ArticleCommentMap : IEntityTypeConfiguration<ArticleComment>
    {
        public void Configure(EntityTypeBuilder<ArticleComment> builder)
        {
            builder.ToTable(@"ArticleComments", @"dbo");
            builder.HasKey(x => x.ArticleCommentId );
            builder.Property(x => x.ArticleId).HasColumnName("ArticleId");
            builder.Property(x => x.AuthorFullName).HasColumnName("AuthorFullName");
            builder.Property(x => x.AuthorEmail).HasColumnName("AuthorEmail");
            builder.Property(x => x.CreateDate).HasColumnName("CreateDate");
            builder.Property(x => x.IsApproved).HasColumnName("IsApproved");
        }
    }
}

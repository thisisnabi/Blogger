using Blogger.Domain.ArticleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogger.Infrastructure.Persistence.Configurations;
internal class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable(BloggerDbContextSchema.Article.TableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .HasConversion(
                    id => id.Slug,
                    value => ArticleId.Create(value));

        builder.Property(x => x.Title)
               .IsRequired()
               .HasMaxLength(70)
               .IsUnicode(false);

        builder.Property(x => x.Summary)
               .IsRequired()
               .HasMaxLength(300)
               .IsUnicode(false);

        builder.Property(x => x.Body)
               .IsRequired()
               .IsUnicode(true);

        builder.Property(x => x.PublishedOnUtc)
                .IsRequired(false);

        builder.Property(x => x.ReadOn)
                .IsRequired(false);

        builder.Property(x => x.Status)
                .IsRequired();


        builder.OwnsOne(x => x.Author, ab =>
        {
            ab.Property(x => x.Avatar)
                       .IsRequired()
                       .HasMaxLength(1024)
                       .HasColumnName(BloggerDbContextSchema.Article.AuthorAvatar);

            ab.Property(x => x.JobTitle)
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnName(BloggerDbContextSchema.Article.AuthorJobTitle);

            ab.Property(x => x.FullName)
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnName(BloggerDbContextSchema.Article.AuthorFullName);
        });
         
        builder.OwnsMany(x => x.CommnetIds, cb =>
        {
            cb.ToTable(BloggerDbContextSchema.Article.CommentIdTableName);

            cb.Property(x => x.Value)
                .HasColumnName(BloggerDbContextSchema.Comment.ForeignKey);

        }).UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Navigation(x => x.CommnetIds)
                    .Metadata.SetField(BloggerDbContextSchema.Article.CommentIdBackendField);

        builder.OwnsMany(x => x.Tags, tb =>
        {
            tb.ToTable(BloggerDbContextSchema.Article.TagTableName);

            tb.Property(x => x.Value)
                .IsRequired()
                .HasMaxLength(30);
        }).UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Navigation(x => x.Tags)
            .Metadata.SetField(BloggerDbContextSchema.Article.TagIdBackendField);
    }
}

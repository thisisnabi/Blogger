using Blogger.Domain.ArticleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogger.Infrastructure.Persistence.Configurations;
internal class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable(BloggerDbContextSchema.ArticleDbSchema.TableName);

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
                .IsRequired(true);

        builder.Property(x => x.ReadOn)
                .IsRequired(false);

        builder.Property(x => x.Status)
                .IsRequired();


        builder.OwnsOne(x => x.Author, ab =>
        {
            ab.Property(x => x.Avatar)
                       .IsRequired()
                       .HasMaxLength(1024)
                       .HasColumnName(BloggerDbContextSchema.ArticleDbSchema.AuthorAvatar);

            ab.Property(x => x.JobTitle)
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnName(BloggerDbContextSchema.ArticleDbSchema.AuthorJobTitle);

            ab.Property(x => x.FullName)
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnName(BloggerDbContextSchema.ArticleDbSchema.AuthorFullName);
        });
         
        builder.OwnsMany(x => x.CommentIds, cb =>
        {
            cb.ToTable(BloggerDbContextSchema.ArticleDbSchema.CommentIdTableName);

            cb.Property(x => x.Value)
                .HasColumnName(BloggerDbContextSchema.CommentDbSchema.ForeignKey);

        }).UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Navigation(x => x.CommentIds)
                    .Metadata.SetField(BloggerDbContextSchema.ArticleDbSchema.CommentIdBackendField);

        builder.OwnsMany(x => x.Tags, tb =>
        {
            tb.ToTable(BloggerDbContextSchema.ArticleDbSchema.TagTableName);

            tb.Property(x => x.Value)
                .IsRequired()
                .HasMaxLength(30);
        }).UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Navigation(x => x.Tags)
            .Metadata.SetField(BloggerDbContextSchema.ArticleDbSchema.TagIdBackendField);
    }
}

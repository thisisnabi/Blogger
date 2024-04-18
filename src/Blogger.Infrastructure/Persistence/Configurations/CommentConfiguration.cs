using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.CommentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogger.Infrastructure.Persistence.Configurations;
internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable(BloggerDbContextSchema.Comment.TableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
             .ValueGeneratedNever()
             .IsRequired()
             .HasConversion(
                    id => id.Value,
                    value => CommentId.Create(value));

        builder.Property(x => x.Content)
                 .HasMaxLength(500)
                 .IsUnicode(false)
                 .IsRequired();

        builder.Property(x => x.IsApproved)
                 .IsRequired();

        builder.Property(x => x.CreatedOnUtc)
                  .IsRequired();
 
        builder.OwnsOne(x => x.Client, cb =>
        {
            cb.Property(c => c.FullName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true)
                .HasColumnName(BloggerDbContextSchema.Comment.ClientFullName);

            cb.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(1044)
                .IsUnicode(true)
                .HasColumnName(BloggerDbContextSchema.Comment.ClientEmail);
        });

        builder.OwnsOne(x => x.ApproveLink, cb =>
        {
            cb.Property(c => c.ExpirationOnUtc)
                .IsRequired()
                .HasColumnName(BloggerDbContextSchema.Comment.ApproveLinkExpirationOnUtc);

            cb.Property(c => c.ApproveId)
                .IsRequired()
                .HasMaxLength(2077)
                .HasColumnName(BloggerDbContextSchema.Comment.ApproveLinkApproveId);
        });

        builder.OwnsOne(x => x.ArticleId, cb =>
        {
            cb.Property(c => c.Slug)
                .IsRequired()
                .HasColumnName(BloggerDbContextSchema.Comment.ArticleId);
        });


        builder.OwnsMany(x => x.Replaies, rb =>
        {
            rb.ToTable(BloggerDbContextSchema.Comment.ReplaiesTableName);

            rb.HasKey(x => x.Id);

            rb.WithOwner()
               .HasForeignKey(BloggerDbContextSchema.Comment.ForeignKey);

            rb.Property(x => x.Id)
                         .ValueGeneratedNever()
                         .IsRequired()
                         .HasConversion(
                                id => id.Value,
                                value => ReplayId.Create(value));

            rb.Property(x => x.Content)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .IsRequired();

            rb.Property(x => x.IsApproved)
                     .IsRequired();

            rb.Property(x => x.CreatedOnUtc)
                      .IsRequired();

            rb.OwnsOne(x => x.Client, cb =>
            {
                cb.Property(c => c.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(true)
                    .HasColumnName(BloggerDbContextSchema.Comment.ClientFullName);

                cb.Property(c => c.Email)
                    .IsRequired()
                    .HasMaxLength(1044)
                    .IsUnicode(true)
                    .HasColumnName(BloggerDbContextSchema.Comment.ClientEmail);
            });

            rb.OwnsOne(x => x.ApproveLink, cb =>
            {
                cb.Property(c => c.ExpirationOnUtc)
                    .IsRequired()
                    .HasColumnName(BloggerDbContextSchema.Comment.ApproveLinkExpirationOnUtc);

                cb.Property(c => c.ApproveId)
                    .IsRequired()
                    .HasMaxLength(2077)
                    .HasColumnName(BloggerDbContextSchema.Comment.ApproveLinkApproveId);
            });
        }).UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Navigation(s => s.Replaies)
                     .Metadata.SetField(BloggerDbContextSchema.Comment.ReplaiesBackendField);

    }
}
using Blogger.Domain.ArticleAggregate;
using Blogger.Domain.CommentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogger.Infrastructure.Persistence.Configurations;
internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable(BloggerDbContextSchema.CommentDbSchema.TableName);

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
                .HasColumnName(BloggerDbContextSchema.CommentDbSchema.ClientFullName);

            cb.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(1044)
                .IsUnicode(true)
                .HasColumnName(BloggerDbContextSchema.CommentDbSchema.ClientEmail);
        });

        builder.OwnsOne(x => x.ApproveLink, cb =>
        {
            cb.Property(c => c.ExpirationOnUtc)
                .IsRequired()
                .HasColumnName(BloggerDbContextSchema.CommentDbSchema.ApproveLinkExpirationOnUtc);

            cb.Property(c => c.ApproveId)
                .IsRequired()
                .HasMaxLength(2077)
                .HasColumnName(BloggerDbContextSchema.CommentDbSchema.ApproveLinkApproveId);
        });

        builder.OwnsOne(x => x.ArticleId, cb =>
        {
            cb.Property(c => c.Slug)
                .IsRequired()
                .HasColumnName(BloggerDbContextSchema.CommentDbSchema.ArticleId);
        });


        builder.OwnsMany(x => x.Replies, rb =>
        {
            rb.ToTable(BloggerDbContextSchema.CommentDbSchema.RepliesTableName);

            rb.HasKey(x => x.Id);

            rb.WithOwner()
               .HasForeignKey(BloggerDbContextSchema.CommentDbSchema.ForeignKey);

            rb.Property(x => x.Id)
                         .ValueGeneratedNever()
                         .IsRequired()
                         .HasConversion(
                                id => id.Value,
                                value => ReplyId.Create(value));

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
                    .HasColumnName(BloggerDbContextSchema.CommentDbSchema.ClientFullName);

                cb.Property(c => c.Email)
                    .IsRequired()
                    .HasMaxLength(1044)
                    .IsUnicode(true)
                    .HasColumnName(BloggerDbContextSchema.CommentDbSchema.ClientEmail);
            });

            rb.OwnsOne(x => x.ApproveLink, cb =>
            {
                cb.Property(c => c.ExpirationOnUtc)
                    .IsRequired()
                    .HasColumnName(BloggerDbContextSchema.CommentDbSchema.ApproveLinkExpirationOnUtc);

                cb.Property(c => c.ApproveId)
                    .IsRequired()
                    .HasMaxLength(2077)
                    .HasColumnName(BloggerDbContextSchema.CommentDbSchema.ApproveLinkApproveId);
            });
        }).UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Navigation(s => s.Replies)
                     .Metadata.SetField(BloggerDbContextSchema.CommentDbSchema.RepliesBackendField);

    }
}
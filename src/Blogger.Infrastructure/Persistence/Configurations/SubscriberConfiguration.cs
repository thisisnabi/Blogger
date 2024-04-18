using Blogger.Domain.SubscriberAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogger.Infrastructure.Persistence.Configurations;
internal class SubscriberConfiguration : IEntityTypeConfiguration<Subscriber>
{
    public void Configure(EntityTypeBuilder<Subscriber> builder)
    {
        builder.ToTable(BloggerDbContextSchema.Subscriber.TableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .HasConversion(
                    id => id.Email,
                    value => SubscriberId.Create(value));

        builder.Property(x => x.JoinedOnUtc)
               .IsRequired();

        builder.OwnsMany(x => x.ArticleIds, sb =>
        {
            sb.ToTable(BloggerDbContextSchema.Subscriber.ArticleIdTableName);

            sb.Property(x => x.Slug)
                .HasColumnName(BloggerDbContextSchema.Article.ForeignKey);

        }).UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Navigation(x => x.ArticleIds)
                    .Metadata.SetField(BloggerDbContextSchema.Subscriber.ArticleIdBackendField);
    }
}

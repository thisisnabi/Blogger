namespace Blogger.Domain.ArticleAggregate;
public class Author : ValueObject<Author>
{
        public string FullName { get; init; }

        public string Avatar { get; init; }

        public string JobTitle { get; init; }

    private Author(string fullName, string avatar, string jobTitle)
    {
        FullName = fullName;
        Avatar = avatar;
        JobTitle = jobTitle;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return FullName;
        yield return Avatar;
        yield return JobTitle;
    }

    public static Author CreateDefaultAuthor() => Create("Nabi Karampour", "/images/avatars/thisisnabi.png", "Senior Software Engineer");

    public static Author Create(string fullName, string avatar, string jobTitle)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fullName);
        ArgumentException.ThrowIfNullOrWhiteSpace(avatar);
        ArgumentException.ThrowIfNullOrWhiteSpace(jobTitle);
        
        return new Author(fullName, avatar, jobTitle);
    }
}

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

    public static Author CreateDefaultAuthor() => 
        Create("Nabi Karampour", 
                "https://avatars.githubusercontent.com/u/3371886?s=400&u=cb8ebf9fc27e463b5d7002aaeeef881eb950b71f&v=4",
                "Senior Software Engineer");

    public static Author Create(string fullName, string avatar, string jobTitle)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fullName);
        ArgumentException.ThrowIfNullOrWhiteSpace(avatar);
        ArgumentException.ThrowIfNullOrWhiteSpace(jobTitle);
        
        return new Author(fullName, avatar, jobTitle);
    }
}

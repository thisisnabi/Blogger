using Blogger.Domain.ArticleAggregate;

namespace Blogger.UnitTests.Domain.Authors;
public class AuthorBuilder
{
    private readonly Defaults _defaults = new();
    public static AuthorBuilder CreateBuilder() => new();
    public AuthorBuilder SetFullName(string fullName)
    {
        _defaults.FullName = fullName;
        return this;
    }
    public AuthorBuilder SetAvatar(string avatar)
    {
        _defaults.Avatar = avatar;
        return this;
    }
    public AuthorBuilder SetJobTitle(string jobTitle)
    {
        _defaults.JobTitle = jobTitle;
        return this;
    }
    public Author Build()
    {
        return Author.Create(_defaults.FullName,
                                        _defaults.Avatar,
                                        _defaults.JobTitle);
    }
    public class Defaults
    {
        public static string FullNameDefaultValue => "Fatemeh Fathollahi";
        public string FullName { set; get; } = FullNameDefaultValue;
        public static string AvatarDefaultValue => "../../images/thisisnabi.png";
        public string Avatar { set; get; } = AvatarDefaultValue;
        public static string JobTitleDefaultValue => "Software Developer";
        public string JobTitle { set; get; } = JobTitleDefaultValue;
    }
}
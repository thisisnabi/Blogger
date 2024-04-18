namespace Blogger.Application.Services;
public class LinkGenerator : ILinkGenerator
{
    public string Generate()
    {
        // implement a generator algorithm
        return Guid.NewGuid().ToString();
    }
}

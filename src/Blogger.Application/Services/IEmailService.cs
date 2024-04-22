namespace Blogger.Application.Services;
public interface IEmailService
{
    Task SendAsync(string email, string subject, string content, CancellationToken cancellationToken);
}

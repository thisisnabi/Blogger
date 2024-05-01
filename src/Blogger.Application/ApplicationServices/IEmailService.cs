namespace Blogger.Application.ApplicationServices;
public interface IEmailService
{
    Task SendAsync(string email, string subject, string content, CancellationToken cancellationToken);
}

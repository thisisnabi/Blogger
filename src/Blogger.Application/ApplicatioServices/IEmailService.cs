namespace Blogger.Application.ApplicatioServices;
public interface IEmailService
{
    Task SendAsync(string email, string subject, string content, CancellationToken cancellationToken);
}

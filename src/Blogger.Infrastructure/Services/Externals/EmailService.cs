using Blogger.Application.ApplicatioServices;

namespace Blogger.Infrastructure.Services.Externals;

public class EmailService : IEmailService
{
    public Task SendAsync(string email, string subject, string content, CancellationToken cancellationToken)
    {
        
        return Task.CompletedTask;
    }
}

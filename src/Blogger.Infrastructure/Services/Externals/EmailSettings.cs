namespace Blogger.Infrastructure.Services.Externals;

public class EmailSettings
{
    public string From { get; set; } = null!;

    public string SmtpHost { get; set; } = null!;

    public int SmtpPort { get; set; }

    public string AppPassword { get; set; } = null!;
}

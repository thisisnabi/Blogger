using Blogger.Application.ApplicationServices;
using Blogger.Domain.Events.ArticleCreated;
using Blogger.Domain.SubscriberAggregate;

namespace Blogger.Application.Events.ArticleCreated;
public class ArticleCreatedHandler(IEmailService emailService, ISubscriberRepository subscriberRepository) : INotificationHandler<ArticleCreatedEvent>
{
    public async Task Handle(ArticleCreatedEvent request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var subscribers = await subscriberRepository.FindByArticleId(request.Article.Id);
        if(subscribers.Count == 0)
        {
            return;
        }

        var tasks = new List<Task>();        
        subscribers.ForEach(x => 
            tasks.Add(emailService.SendAsync(x.Id.Email, "Article Notification", $"article {request.Article.Title} has been publish.", cancellationToken))
        );

        await Task.WhenAll(tasks);
    }
}

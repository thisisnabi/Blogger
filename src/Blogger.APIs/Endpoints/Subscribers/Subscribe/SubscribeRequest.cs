using System.ComponentModel.DataAnnotations;

namespace Blogger.APIs.Endpoints.Subscribers.Subscribe;

public record SubscribeRequest([FromBody][EmailAddress] string Email);

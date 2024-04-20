using System.ComponentModel.DataAnnotations;

namespace Blogger.APIs.Contracts.Subscribe;

public record SubscribeRequest([FromBody][EmailAddress]string Email);

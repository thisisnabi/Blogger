namespace Blogger.Domain.ClientAggregate;
public interface IClientService
{
    Task<bool> IsValid(ClientId clientId);
}

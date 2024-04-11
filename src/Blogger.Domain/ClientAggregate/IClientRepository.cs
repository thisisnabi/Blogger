
namespace Blogger.Domain.ClientAggregate;

public interface IClientRepository
{
    Task<Client> FindById(ClientId clientId);
}

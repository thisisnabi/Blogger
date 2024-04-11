using Blogger.Domain.ClientAggregate;

namespace Blogger.Application.Services;
internal class ClientService(IClientRepository clientRepository) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;
    public async Task<bool> IsValid(ClientId clientId)
    {
       var client = await _clientRepository.FindById(clientId);
       return client is not null;  
    }
}

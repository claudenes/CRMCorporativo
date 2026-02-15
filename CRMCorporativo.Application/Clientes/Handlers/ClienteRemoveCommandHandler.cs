using CRMCorporativo.Application.Clientes.Commands;
using CRMCorporativo.Domain.Entities;
using CRMCorporativo.Domain.Interfaces;
using MediatR;

namespace CRMCorporativo.Application.Clientes.Handlers;

public class ClienteRemoveCommandHandler : IRequestHandler<ClienteRemoveCommand, Cliente>
{
    private readonly IClienteRepository _clienteRepository;
    public ClienteRemoveCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository ?? throw new
            ArgumentNullException(nameof(clienteRepository));
    }

    public async Task<Cliente> Handle(ClienteRemoveCommand request,
        CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.GetByIdAsync(request.Id);

        if (cliente == null)
        {
            throw new ApplicationException($"Entity could not be found.");
        }
        else
        {
            var result = await _clienteRepository.RemoveAsync(cliente);
            return result;
        }
    }
}

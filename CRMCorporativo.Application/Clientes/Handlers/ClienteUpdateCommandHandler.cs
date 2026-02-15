using CRMCorporativo.Application.Clientes.Commands;
using CRMCorporativo.Domain.Entities;
using CRMCorporativo.Domain.Interfaces;
using MediatR;

namespace CRMCorporativo.Application.Clientes.Handlers;

public class ClienteUpdateCommandHandler : IRequestHandler<ClienteUpdateCommand, Cliente>
{
    private readonly IClienteRepository _clienteRepository;
    public ClienteUpdateCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository ??
        throw new ArgumentNullException(nameof(clienteRepository));
    }

    public async Task<Cliente> Handle(ClienteUpdateCommand request,
        CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.GetByIdAsync(request.Id);

        if (cliente == null)
        {
            throw new ApplicationException($"Entity could not be found.");
        }
        else
        {
            cliente.Update(request.Nome, request.CPFCNPJ, request.DataNascimento,
                            request.Telefone, request.Email, request.EnderecoId);

            return await _clienteRepository.UpdateAsync(cliente);

        }
    }
}

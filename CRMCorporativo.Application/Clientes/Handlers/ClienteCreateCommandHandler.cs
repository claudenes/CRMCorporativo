using CRMCorporativo.Application.Clientes.Commands;
using CRMCorporativo.Domain.Entities;
using CRMCorporativo.Domain.Interfaces;
using MediatR;

namespace CRMCorporativo.Application.Clientes.Handlers;

public class ClienteCreateCommandHandler : IRequestHandler<ClienteCreateCommand, Cliente>
{
    private readonly IClienteRepository _clienteRepository;
    public ClienteCreateCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
    public async Task<Cliente> Handle(ClienteCreateCommand request,
        CancellationToken cancellationToken)
    {
        var cliente = new Cliente(request.Nome, request.CPFCNPJ, request.DataNascimento,
                          request.Telefone, request.Email);

        if (cliente == null)
        {
            throw new ApplicationException($"Error creating entity.");
        }
        else
        {
            cliente.EnderecoId = request.EnderecoId;
            return await _clienteRepository.CreateAsync(cliente);
        }
    }
}

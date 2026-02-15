using CRMCorporativo.Application.Clientes.Queries;
using CRMCorporativo.Domain.Entities;
using CRMCorporativo.Domain.Interfaces;
using MediatR;

namespace CRMCorporativo.Application.Clientes.Handlers;

public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, Cliente>
{
    private readonly IClienteRepository _clienteRepository;
    public GetClienteByIdQueryHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Cliente> Handle(GetClienteByIdQuery request,
         CancellationToken cancellationToken)
    {
        return await _clienteRepository.GetByIdAsync(request.Id);
    }
}

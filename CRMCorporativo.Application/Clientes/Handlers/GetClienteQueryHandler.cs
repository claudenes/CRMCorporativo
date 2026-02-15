using CRMCorporativo.Application.Clientes.Queries;
using CRMCorporativo.Domain.Entities;
using CRMCorporativo.Domain.Interfaces;
using MediatR;

namespace CRMCorporativo.Application.Clientes.Handlers;

public class GetClienteQueryHandler : IRequestHandler<GetClientesQuery, IEnumerable<Cliente>>
{
    private readonly IClienteRepository _clienteRepository;

    public GetClienteQueryHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<IEnumerable<Cliente>> Handle(GetClientesQuery request,
        CancellationToken cancellationToken)
    {
        return await _clienteRepository.GetClientesAsync();
    }
}

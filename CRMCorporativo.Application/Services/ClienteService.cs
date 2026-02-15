using AutoMapper;
using CRMCorporativo.Application.DTOs;
using CRMCorporativo.Application.Interfaces;
using CRMCorporativo.Application.Clientes.Commands;
using CRMCorporativo.Application.Clientes.Queries;
using MediatR;

namespace CRMCorporativo.Application.Services;

public class ClienteService : IClienteService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public ClienteService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IEnumerable<ClienteDTO>> GetClientes()
    {
        var clienteQuery = new GetClientesQuery();

        if (clienteQuery == null)
            throw new Exception($"Entity could not be loaded.");

        var result = await _mediator.Send(clienteQuery);

        return _mapper.Map<IEnumerable<ClienteDTO>>(result);
    }

    public async Task<ClienteDTO> GetById(int? id)
    {
        var clienteByIdQuery = new GetClienteByIdQuery(id.Value);

        if (clienteByIdQuery == null)
            throw new Exception($"Entity could not be loaded.");

        var result = await _mediator.Send(clienteByIdQuery);

        return _mapper.Map<ClienteDTO>(result);
    }

    public async Task Add(ClienteDTO clienteDto)
    {
        var clienteCreateCommand = _mapper.Map<ClienteCreateCommand>(clienteDto);
        await _mediator.Send(clienteCreateCommand);
    }

    public async Task Update(ClienteDTO clienteDto)
    {
        var clienteUpdateCommand = _mapper.Map<ClienteUpdateCommand>(clienteDto);
        await _mediator.Send(clienteUpdateCommand);
    }

    public async Task Remove(int? id)
    {
        var clienteRemoveCommand = new ClienteRemoveCommand(id.Value);
        if (clienteRemoveCommand == null)
            throw new Exception($"Entity could not be loaded.");

        await _mediator.Send(clienteRemoveCommand);
    }
}

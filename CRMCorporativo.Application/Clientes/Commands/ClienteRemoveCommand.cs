using CRMCorporativo.Domain.Entities;
using MediatR;

namespace CRMCorporativo.Application.Clientes.Commands;

public class ClienteRemoveCommand : IRequest<Cliente>
{
    public int Id { get; set; }
    public ClienteRemoveCommand(int id)
    {
        Id = id;
    }
}

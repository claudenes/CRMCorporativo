using CRMCorporativo.Domain.Entities;
using MediatR;

namespace CRMCorporativo.Application.Clientes.Queries;

public class GetClienteByIdQuery : IRequest<Cliente>
{
    public int Id { get; set; }
    public GetClienteByIdQuery(int id)
    {
        Id = id;
    }
}

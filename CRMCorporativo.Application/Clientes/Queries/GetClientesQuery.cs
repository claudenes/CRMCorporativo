using CRMCorporativo.Domain.Entities;
using MediatR;

namespace CRMCorporativo.Application.Clientes.Queries;

public class GetClientesQuery : IRequest<IEnumerable<Cliente>>
{
}

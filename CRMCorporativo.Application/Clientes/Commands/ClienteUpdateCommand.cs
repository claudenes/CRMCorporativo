using CRMCorporativo.Application.Clientes.Commands;

namespace CRMCorporativo.Application.Clientes.Commands;

public class ClienteUpdateCommand : ClienteCommand
{
    public int Id { get; set; }
}

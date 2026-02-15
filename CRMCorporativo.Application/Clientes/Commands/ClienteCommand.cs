using CRMCorporativo.Domain.Entities;
using MediatR;

namespace CRMCorporativo.Application.Clientes.Commands;

public abstract class ClienteCommand : IRequest<Cliente>
{
    public string Nome { get; set; }
    public string CPFCNPJ { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
        public int EnderecoId { get; set; }
}

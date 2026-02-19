using CRMCorporativo.Domain.Entities;

namespace CRMCorporativo.Domain.Interfaces;

public interface IEnderecoRepository
{
    Task<IEnumerable<Endereco>> GetEnderecos();
    Task<Endereco> GetById(int? id);

    Task<Endereco> Create(Endereco endereco);
    Task<Endereco> Update(Endereco endereco);
    Task<Endereco> Remove(Endereco endereco);
}

using CRMCorporativo.Domain.Entities;
using CRMCorporativo.Domain.Interfaces;
using CRMCorporativo.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CRMCorporativo.Infra.Data.Repositories;

public class EnderecoRepository : IEnderecoRepository
{
    private ApplicationDbContext _enderecoContext;
    public EnderecoRepository(ApplicationDbContext context)
    {
        _enderecoContext = context;
    }

    public async Task<Endereco> Create(Endereco endereco)
    {
        _enderecoContext.Add(endereco);
        await _enderecoContext.SaveChangesAsync();
        return endereco;
    }

    public async Task<Endereco> GetById(int? id)
    {
        var endereco = await _enderecoContext.Enderecos.FindAsync(id);
        return endereco;
    }

    public async Task<IEnumerable<Endereco>> GetEnderecos()
    {
        return await _enderecoContext.Enderecos.OrderBy(c => c.Logradouro).ToListAsync();
    }

    public async Task<Endereco> Remove(Endereco endereco)
    {
        _enderecoContext.Remove(endereco);
        await _enderecoContext.SaveChangesAsync();
        return endereco;
    }

    public async Task<Endereco> Update(Endereco endereco)
    {
        _enderecoContext.Update(endereco);
        await _enderecoContext.SaveChangesAsync();
        return endereco;
    }
}

using CRMCorporativo.Domain.Entities;
using CRMCorporativo.Domain.Interfaces;
using CRMCorporativo.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CRMCorporativo.Infra.Data.Repositories;

public class ClienteRepository : IClienteRepository
{
    private ApplicationDbContext _clienteContext;
    public ClienteRepository(ApplicationDbContext context)
    {
        _clienteContext = context;
    }

    public async Task<Cliente> CreateAsync(Cliente cliente)
    {
        _clienteContext.Add(cliente);
        await _clienteContext.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente> GetByIdAsync(int? id)
    {
        return await _clienteContext.Clientes.Include(c => c.Endereco)
           .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Cliente>> GetClientesAsync()
    {
        return await _clienteContext.Clientes.ToListAsync();
    }

    public async Task<Cliente> RemoveAsync(Cliente cliente)
    {
        _clienteContext.Remove(cliente);
        await _clienteContext.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente> UpdateAsync(Cliente cliente)
    {
        _clienteContext.Update(cliente);
        await _clienteContext.SaveChangesAsync();
        return cliente;
    }
}

using CRMCorporativo.Domain.Entities;

namespace CRMCorporativo.Domain.Interfaces;

public interface IClienteRepository
{
    Task<IEnumerable<Cliente>> GetClientesAsync();
    Task<Cliente> GetByIdAsync(int? id);

    //Task<Product> GetProductCategoryAsync(int? id);

    Task<Cliente> CreateAsync(Cliente cliente);
    Task<Cliente> UpdateAsync(Cliente cliente);
    Task<Cliente> RemoveAsync(Cliente cliente);
}

using CRMCorporativo.Application.DTOs;

namespace CRMCorporativo.Application.Interfaces;

public interface IClienteService
{
    Task<IEnumerable<ClienteDTO>> GetClientes();
    Task<ClienteDTO> GetById(int? id);

    //Task<ProductDTO> GetProductCategory(int? id);
    Task Add(ClienteDTO clienteDto);
    Task Update(ClienteDTO clienteDto);
    Task Remove(int? id);
}

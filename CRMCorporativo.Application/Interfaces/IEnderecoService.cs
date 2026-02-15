using CRMCorporativo.Application.DTOs;

namespace CRMCorporativo.Application.Interfaces;

public interface IEnderecoService
{
    Task<IEnumerable<EnderecoDTO>> GetCategories();
    Task<EnderecoDTO> GetById(int? id);
    Task Add(EnderecoDTO enderecoDto);
    Task Update(EnderecoDTO enderecoDto);
    Task Remove(int? id);
}

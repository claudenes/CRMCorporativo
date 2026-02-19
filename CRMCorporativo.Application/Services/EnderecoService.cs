using AutoMapper;
using CRMCorporativo.Application.DTOs;
using CRMCorporativo.Application.Interfaces;
using CRMCorporativo.Domain.Entities;
using CRMCorporativo.Domain.Interfaces;

namespace CRMCorporativo.Application.Services;

public class EnderecoService : IEnderecoService
{
    private IEnderecoRepository _enderecoRepository;
    private readonly IMapper _mapper;
    public EnderecoService(IEnderecoRepository enderecoRepository, IMapper mapper)
    {
        _enderecoRepository = enderecoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EnderecoDTO>> GetEnderecos()
    {
        var enderecoEntity = await _enderecoRepository.GetEnderecos();
        return _mapper.Map<IEnumerable<EnderecoDTO>>(enderecoEntity);
    }

    public async Task<EnderecoDTO> GetById(int? id)
    {
        var enderecoEntity = await _enderecoRepository.GetById(id);
        return _mapper.Map<EnderecoDTO>(enderecoEntity);
    }

    public async Task Add(EnderecoDTO enderecoDto)
    {
        var enderecoEntity = _mapper.Map<Endereco>(enderecoDto);
        await _enderecoRepository.Create(enderecoEntity);
        enderecoDto.Id = enderecoEntity.Id;
    }

    public async Task Update(EnderecoDTO enderecoDto)
    {
        var enderecoEntity = _mapper.Map<Endereco>(enderecoDto);
        await _enderecoRepository.Update(enderecoEntity);
    }

    public async Task Remove(int? id)
    {
        var enderecoEntity = _enderecoRepository.GetById(id).Result;
        await _enderecoRepository.Remove(enderecoEntity);
    }
}

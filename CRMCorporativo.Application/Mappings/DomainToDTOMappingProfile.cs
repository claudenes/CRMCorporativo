using AutoMapper;
using CRMCorporativo.Application.DTOs;
using CRMCorporativo.Domain.Entities;

namespace CRMCorporativo.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Endereco, EnderecoDTO>().ReverseMap();
        CreateMap<Cliente, ClienteDTO>().ReverseMap();
    }
}

using AutoMapper;
using CRMCorporativo.Application.DTOs;
using CRMCorporativo.Application.Clientes.Commands;

namespace CRMCorporativo.Application.Mappings;

public class DTOToCommandMappingProfile : Profile
{
    public DTOToCommandMappingProfile()
    {
        CreateMap<ClienteDTO, ClienteCreateCommand>();
        CreateMap<ClienteDTO, ClienteUpdateCommand>();
    }
}

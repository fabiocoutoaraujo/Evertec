using AutoMapper;
using FCA.Application.DTOs;
using FCA.Domain.Entities;

namespace FCA.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Proprietario, ProprietarioDTO>().ReverseMap();
        CreateMap<Veiculo, VeiculoDTO>().ReverseMap();
    }
}

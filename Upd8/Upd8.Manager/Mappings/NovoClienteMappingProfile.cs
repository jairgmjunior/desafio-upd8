using AutoMapper;
using Upd8.Core.Domain;
using Upd8.Core.Enums;
using Upd8.Core.Shared.ViewModels;

namespace Upd8.Manager.Mappings
{
    public class NovoClienteMappingProfile : Profile
    {
        public NovoClienteMappingProfile()
        {
            CreateMap<NovoEnderecoViewModel, Endereco>()
                .ForMember(p => p.Complemento, o => o.MapFrom(x => x.Complemento))
                .ForPath(p => p.Cidade.CodigoIbge, o => o.MapFrom(x => x.CodigoIbge));

            CreateMap<NovoClienteViewModel, Cliente>()
            .ForMember(dest => dest.DataCriacao, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
            .ForMember(dest => dest.DataAtualizacao, opt => opt.Ignore())
            .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.CPF.Trim()))
            .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Sexo))
            .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
            .ForPath(dest => dest.Endereco.Cidade.CodigoIbge, opt => opt.MapFrom(src => src.Endereco.CodigoIbge))
            .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.CPF.Trim()));
        }
    }
}

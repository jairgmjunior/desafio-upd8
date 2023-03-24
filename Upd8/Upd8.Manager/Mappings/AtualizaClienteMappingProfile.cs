using AutoMapper;
using Upd8.Core.Domain;
using Upd8.Core.Shared.ViewModels;

namespace Upd8.Manager.Mappings
{
    public class AtualizaClienteMappingProfile : Profile
    {
        public AtualizaClienteMappingProfile()
        {
            CreateMap<AtualizaClienteViewModel, Cliente>()
                .ForMember(p => p.DataAtualizacao, o => o.MapFrom(x => DateTime.Now));

        }
    }
}

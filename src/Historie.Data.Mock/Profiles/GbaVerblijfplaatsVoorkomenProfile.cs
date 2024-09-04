using AutoMapper;
using Historie.Data.Mock.Entities;
using Historie.Data.Mock.Generated;

namespace Historie.Data.Mock.Profiles;

public class GbaVerblijfplaatsVoorkomenProfile : Profile
{
    public GbaVerblijfplaatsVoorkomenProfile()
    {
        CreateMap<Verblijfplaats, GbaVerblijfplaatsVoorkomen>()
            .ForMember(dest => dest.DatumAanvangVolgendeAdreshouding, opt => opt.MapFrom(src => src.DatumEindeAdreshouding))
            .ForMember(dest => dest.DatumAanvangVolgendeAdresBuitenland, opt => opt.MapFrom(src => src.DatumEindeAdresBuitenland));
    }
}

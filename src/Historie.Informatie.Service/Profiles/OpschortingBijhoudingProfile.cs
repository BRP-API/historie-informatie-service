using AutoMapper;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;
using Historie.Informatie.Service.Mappers;

namespace Historie.Informatie.Service.Profiles;

public class OpschortingBijhoudingProfile : Profile
{
    public OpschortingBijhoudingProfile()
    {
        CreateMap<GbaOpschortingBijhouding, OpschortingBijhouding>()
            .ForMember(dest => dest.Datum, opt => opt.MapFrom(src => src.Datum.Map()))
            ;
    }
}

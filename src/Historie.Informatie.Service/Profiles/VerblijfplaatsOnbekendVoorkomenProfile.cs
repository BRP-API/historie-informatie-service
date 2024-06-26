using AutoMapper;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;
using Historie.Informatie.Service.Mappers;

namespace Historie.Informatie.Service.Profiles;

public class VerblijfplaatsOnbekendVoorkomenProfile : Profile
{
    public VerblijfplaatsOnbekendVoorkomenProfile()
    {
        CreateMap<GbaVerblijfplaatsVoorkomen, VerblijfplaatsOnbekendVoorkomen>()
            .ForMember(dest => dest.DatumVan, opt => opt.MapFrom(src => src.MapDatumVan()))
            .ForMember(dest => dest.DatumTot, opt =>
            {
                opt.PreCondition(src => src.HeeftDatumAanvangVolgendeVerblijf());
                opt.MapFrom(src => src.MapDatumTot());
            })
            .AfterMap((src, dest) =>
            {
                dest.InOnderzoek = src.InOnderzoekVolgendeVerblijfplaats.MapDatumAanvangVolgendeVerblijfplaatsInOnderzoek(dest.InOnderzoek);
            })
            ;

        CreateMap<GbaInOnderzoek, VerblijfplaatsOnbekendVoorkomenInOnderzoek?>().ConvertUsing<VerblijfplaatsOnbekendVoorkomenInOnderzoekConverter>();
    }
}

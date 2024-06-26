using AutoMapper;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;
using Historie.Informatie.Service.Mappers;

namespace Historie.Informatie.Service.Profiles;

public class VerblijfplaatsBuitenlandVoorkomenProfile : Profile
{
    public VerblijfplaatsBuitenlandVoorkomenProfile()
    {
        CreateMap<GbaVerblijfplaatsVoorkomen, AdresseringBuitenland>()
            .ForMember(dest => dest.Adresregel1, opt => opt.MapFrom(src => src.Adresregel1()))
            .ForMember(dest => dest.Adresregel2, opt => opt.MapFrom(src => src.Adresregel2(src.GemeenteVanInschrijving)))
            .ForMember(dest => dest.Adresregel3, opt => opt.MapFrom(src => src.Adresregel3()))
            .ForMember(dest => dest.Land, opt => opt.MapFrom(src => src.Land())) 
            ;

        CreateMap<GbaVerblijfplaatsVoorkomen, VerblijfadresBuitenland>()
            ;

        CreateMap<GbaVerblijfplaatsVoorkomen, VerblijfplaatsBuitenlandVoorkomen>()
            .ForMember(dest => dest.Adressering, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.Verblijfadres, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.DatumVan, opt => opt.MapFrom(src => src.DatumAanvangAdresBuitenland.Map()))
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

        CreateMap<GbaInOnderzoek, VerblijfplaatsBuitenlandVoorkomenInOnderzoek?>().ConvertUsing<VerblijfplaatsBuitenlandVoorkomenInOnderzoekConverter>();
        CreateMap<GbaInOnderzoek, VerblijfadresBuitenlandInOnderzoek?>().ConvertUsing<VerblijfadresBuitenlandInOnderzoekConverter>();
        CreateMap<GbaInOnderzoek, AdresseringBuitenlandInOnderzoek?>().ConvertUsing<AdresseringBuitenlandInOnderzoekConverter>();
    }
}

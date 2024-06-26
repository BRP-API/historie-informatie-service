using AutoMapper;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;
using Historie.Informatie.Service.Mappers;

namespace Historie.Informatie.Service.Profiles;

public class LocatieVoorkomenProfile : Profile
{
    public LocatieVoorkomenProfile()
    {
        CreateMap<GbaVerblijfplaatsVoorkomen, AdresseringBinnenland>()
            .ForMember(dest => dest.Adresregel1, opt => opt.MapFrom(src => src.Adresregel1()))
            .ForMember(dest => dest.Adresregel2, opt => opt.MapFrom(src => src.Adresregel2(src.GemeenteVanInschrijving)))
            ;

        CreateMap<GbaVerblijfplaatsVoorkomen, VerblijfadresLocatie>()
            ;

        CreateMap<GbaVerblijfplaatsVoorkomen, LocatieVoorkomen>()
            .ForMember(dest => dest.Adressering, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.Verblijfadres, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.DatumVan, opt => opt.MapFrom(src => src.DatumAanvangAdreshouding.Map()))
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

        CreateMap<GbaInOnderzoek, LocatieVoorkomenInOnderzoek?>().ConvertUsing<LocatieVoorkomenInOnderzoekConverter>();
        CreateMap<GbaInOnderzoek, VerblijfadresLocatieInOnderzoek?>().ConvertUsing<VerblijfadresLocatieInOnderzoekConverter>();
        CreateMap<GbaInOnderzoek, AdresseringBinnenlandInOnderzoek?>().ConvertUsing<AdresseringBinnenlandInOnderzoekConverter>();
    }
}

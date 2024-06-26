using AutoMapper;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;
using Historie.Informatie.Service.Mappers;

namespace Historie.Informatie.Service.Profiles;

public class AdresVoorkomenProfile : Profile
{
    public AdresVoorkomenProfile()
    {
        CreateMap<GbaVerblijfplaatsVoorkomen, AdresseringBinnenland>()
            .ForMember(dest => dest.Adresregel1, opt => opt.MapFrom(src => src.Adresregel1()))
            .ForMember(dest => dest.Adresregel2, opt => opt.MapFrom(src => src.Adresregel2(src.GemeenteVanInschrijving)))
            ;

        CreateMap<GbaVerblijfplaatsVoorkomen, VerblijfadresBinnenland>()
            .ForMember(dest => dest.KorteStraatnaam, opt => {
                opt.PreCondition(src => src.Straat != ".");
                opt.MapFrom(src => src.Straat);
            })
            .ForMember(dest => dest.OfficieleStraatnaam, opt => opt.MapFrom(src => src.NaamOpenbareRuimte))
            ;

        CreateMap<GbaVerblijfplaatsVoorkomen, AdresVoorkomen>()
            .ForMember(dest => dest.Adressering, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.Verblijfadres, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.DatumVan, opt => opt.MapFrom(src => src.DatumAanvangAdreshouding.Map()))
            .ForMember(dest => dest.DatumTot, opt =>
            {
                opt.PreCondition(src => src.HeeftDatumAanvangVolgendeVerblijf());
                opt.MapFrom(src => src.MapDatumTot());
            })
            .ForMember(dest => dest.VerblijftNietOpAdresVanaf, opt => opt.MapFrom(src => src.MapVerblijftNietOpAdres()))
            .AfterMap((src, dest) =>
            {
                dest.InOnderzoek = src.InOnderzoekVolgendeVerblijfplaats.MapDatumAanvangVolgendeVerblijfplaatsInOnderzoek(dest.InOnderzoek);
            })
            ;

        CreateMap<GbaInOnderzoek, AdresVoorkomenInOnderzoek?>().ConvertUsing<AdresVoorkomenInOnderzoekConverter>();
        CreateMap<GbaInOnderzoek, VerblijfadresBinnenlandInOnderzoek?>().ConvertUsing<VerblijfadresBinnenlandInOnderzoekConverter>();
        CreateMap<GbaInOnderzoek, AdresseringBinnenlandInOnderzoek?>().ConvertUsing<AdresseringBinnenlandInOnderzoekConverter>();
    }
}

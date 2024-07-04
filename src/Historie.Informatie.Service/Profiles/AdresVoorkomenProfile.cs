using AutoMapper;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;
using Historie.Informatie.Service.Generated;
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
            .ForMember(dest => dest.VerblijftNietOpAdresVanaf, opt =>
            {
                opt.PreCondition(src => src.InOnderzoek.IsVastgesteldVerblijftNietOpAdres(src.DatumAanvangVolgendeAdreshouding, src.DatumAanvangVolgendeAdresBuitenland));
                opt.MapFrom(src => src.InOnderzoek.DatumIngangOnderzoek.Map());
            })
            .AfterMap((src, dest) =>
            {
                dest.InOnderzoek = src.InOnderzoekVolgendeVerblijfplaats.MapDatumAanvangVolgendeVerblijfplaatsInOnderzoek(dest.InOnderzoek);

                if(src.InOnderzoek != null &&
                new[] { "089999", "589999" }.Contains(src.InOnderzoek.AanduidingGegevensInOnderzoek) &&
                dest.VerblijftNietOpAdresVanaf == null)
                {
                    dest.InOnderzoek = null;
                    dest.Verblijfadres.InOnderzoek = null;
                    dest.Adressering.InOnderzoek = null;
                }
            })
            ;

        CreateMap<GbaInOnderzoek, AdresVoorkomenInOnderzoek?>().ConvertUsing<AdresVoorkomenInOnderzoekConverter>();
        CreateMap<GbaInOnderzoek, VerblijfadresBinnenlandInOnderzoek?>().ConvertUsing<VerblijfadresBinnenlandInOnderzoekConverter>();
        CreateMap<GbaInOnderzoek, AdresseringBinnenlandInOnderzoek?>().ConvertUsing<AdresseringBinnenlandInOnderzoekConverter>();
    }

    //private static bool IsVastgesteldVerblijftNietOpAdres(IBrpInOnderzoek inOnderzoek, string? datumAanvangVolgendeAdreshouding, string? datumAanvangVolgendeAdresBuitenland)
    //{
    //    return inOnderzoek != null &&
    //    new[] { "089999", "589999" }.Contains(inOnderzoek.AanduidingGegevensInOnderzoek) &&
    //    (string.IsNullOrEmpty(inOnderzoek.DatumEindeOnderzoek) ||
    //    DatumEindeValtOpOfNaDatumAanvang(inOnderzoek.DatumEindeOnderzoek, datumAanvangVolgendeAdreshouding, datumAanvangVolgendeAdresBuitenland));
    //}

    //private static bool DatumEindeValtOpOfNaDatumAanvang(string datumEinde, string? datumAanvangVolgendeAdreshouding, string? datumAanvangVolgendeAdresBuitenland)
    //{
    //    if (!string.IsNullOrEmpty(datumEinde) && string.IsNullOrEmpty(datumAanvangVolgendeAdreshouding) && string.IsNullOrEmpty(datumAanvangVolgendeAdresBuitenland)) return false;

    //    if (datumAanvangVolgendeAdreshouding != null && int.Parse(datumEinde) < int.Parse(datumAanvangVolgendeAdreshouding)) return false;

    //    if(datumAanvangVolgendeAdresBuitenland != null && int.Parse(datumEinde) < int.Parse(datumAanvangVolgendeAdresBuitenland)) return false;

    //    return true;
    //}
}

using AutoMapper;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;
using Historie.Informatie.Service.Mappers;

namespace Historie.Informatie.Service.Profiles;

public class VerblijfadresBinnenlandInOnderzoekConverter : ITypeConverter<GbaInOnderzoek, VerblijfadresBinnenlandInOnderzoek?>
{
    public VerblijfadresBinnenlandInOnderzoek? Convert(GbaInOnderzoek source, VerblijfadresBinnenlandInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "080000" or
            "580000" => CategorieVerblijfplaatsInOnderzoek(source),
            "080900" or
            "580900" => GroepGemeenteInOnderzoek(source),
            "080910" or
            "580910" => GemeenteVanInschrijvingInOnderzoek(source),
            "081100" or
            "581100" => GroepAdresInOnderzoek(source),
            "081110" or
            "581110" => StraatnaamInOnderzoek(source),
            "081115" or
            "581115" => OfficieleStraatnaamInOnderzoek(source),
            "081120" or
            "581120" => HuisnummerInOnderzoek(source),
            "081130" or
            "581130" => HuisletterInOnderzoek(source),
            "081140" or
            "581140" => HuisnummertoevoegingInOnderzoek(source),
            "081150" or
            "581150" => AanduidingBijHuisnummerInOnderzoek(source),
            "081160" or
            "581160" => PostcodeInOnderzoek(source),
            "081170" or
            "581170" => WoonplaatsnaamInOnderzoek(source),
            "089999" or
            "589999" => VastgesteldVerblijftNietOpAdresInOnderzoek(source),
            _ => null
        };
    }

    private static VerblijfadresBinnenlandInOnderzoek CategorieVerblijfplaatsInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            AanduidingBijHuisnummer = true,
            Huisletter = true,
            Huisnummer = true,
            Huisnummertoevoeging = true,
            KorteStraatnaam = true,
            Postcode = true,
            OfficieleStraatnaam = true,
            Woonplaats = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfadresBinnenlandInOnderzoek GroepAdresInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            AanduidingBijHuisnummer = true,
            Huisletter = true,
            Huisnummer = true,
            Huisnummertoevoeging = true,
            KorteStraatnaam = true,
            Postcode = true,
            OfficieleStraatnaam = true,
            Woonplaats = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfadresBinnenlandInOnderzoek GroepGemeenteInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Woonplaats = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfadresBinnenlandInOnderzoek AanduidingBijHuisnummerInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            AanduidingBijHuisnummer = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfadresBinnenlandInOnderzoek GemeenteVanInschrijvingInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Woonplaats = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfadresBinnenlandInOnderzoek HuisletterInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Huisletter = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfadresBinnenlandInOnderzoek HuisnummerInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Huisnummer = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfadresBinnenlandInOnderzoek HuisnummertoevoegingInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Huisnummertoevoeging = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfadresBinnenlandInOnderzoek OfficieleStraatnaamInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            OfficieleStraatnaam = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfadresBinnenlandInOnderzoek PostcodeInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Postcode = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfadresBinnenlandInOnderzoek StraatnaamInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            KorteStraatnaam = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfadresBinnenlandInOnderzoek WoonplaatsnaamInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Woonplaats = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfadresBinnenlandInOnderzoek VastgesteldVerblijftNietOpAdresInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            AanduidingBijHuisnummer = true,
            Huisletter = true,
            Huisnummer = true,
            Huisnummertoevoeging = true,
            KorteStraatnaam = true,
            Postcode = true,
            OfficieleStraatnaam = true,
            Woonplaats = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };
}
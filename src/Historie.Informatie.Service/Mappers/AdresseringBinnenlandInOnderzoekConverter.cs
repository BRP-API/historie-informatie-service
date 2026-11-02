using Brp.Shared.DtoMappers.Mappers;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;

namespace Historie.Informatie.Service.Mappers;

public static class AdresseringBinnenlandInOnderzoekConverter
{
    public static AdresseringBinnenlandInOnderzoek? Convert(GbaInOnderzoek? source)
    {
        if (source is null)
        {
            return null;
        }

        var aanduiding = NormalizeAanduiding(source.AanduidingGegevensInOnderzoek);

        return aanduiding switch
        {
            "080000" => CategorieVerblijfplaatsInOnderzoek(source),
            "080900" => GroepGemeenteInOnderzoek(source),
            "080910" => GemeenteVanInschrijvingInOnderzoek(source),
            "081100" => GroepAdresInOnderzoek(source),
            "081110" => StraatnaamInOnderzoek(source),
            "081115" => OfficieleStraatnaamInOnderzoek(source),
            "081120" => HuisnummerInOnderzoek(source),
            "081130" => HuisletterInOnderzoek(source),
            "081140" => HuisnummertoevoegingInOnderzoek(source),
            "081150" => AanduidingBijHuisnummerInOnderzoek(source),
            "081160" => PostcodeInOnderzoek(source),
            "081170" => WoonplaatsnaamInOnderzoek(source),
            "081200" => GroepLocatieInOnderzoek(source),
            "081210" => LocatiebeschrijvingInOnderzoek(source),
            "089999" => VastgesteldVerblijftNietOpAdresInOnderzoek(source),
            _ => null
        };
    }

    private static string? NormalizeAanduiding(string? aanduiding) =>
        aanduiding?.StartsWith("58", StringComparison.Ordinal) == true
            ? $"08{aanduiding[2..]}"
            : aanduiding;

     private static AdresseringBinnenlandInOnderzoek CategorieVerblijfplaatsInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Adresregel1 = true,
            Adresregel2 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresseringBinnenlandInOnderzoek GroepAdresInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Adresregel1 = true,
            Adresregel2 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresseringBinnenlandInOnderzoek GroepGemeenteInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Adresregel2 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresseringBinnenlandInOnderzoek GroepLocatieInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Adresregel1 = true,
            Adresregel2 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresseringBinnenlandInOnderzoek AanduidingBijHuisnummerInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Adresregel1 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresseringBinnenlandInOnderzoek GemeenteVanInschrijvingInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Adresregel2 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresseringBinnenlandInOnderzoek HuisletterInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Adresregel1 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresseringBinnenlandInOnderzoek HuisnummerInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Adresregel1 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresseringBinnenlandInOnderzoek HuisnummertoevoegingInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Adresregel1 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresseringBinnenlandInOnderzoek LocatiebeschrijvingInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Adresregel1 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresseringBinnenlandInOnderzoek OfficieleStraatnaamInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Adresregel1 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresseringBinnenlandInOnderzoek PostcodeInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Adresregel2 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresseringBinnenlandInOnderzoek StraatnaamInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Adresregel1 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresseringBinnenlandInOnderzoek WoonplaatsnaamInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Adresregel2 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresseringBinnenlandInOnderzoek VastgesteldVerblijftNietOpAdresInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Adresregel1 = true,
            Adresregel2 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };
}

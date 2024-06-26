using AutoMapper;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;
using Historie.Informatie.Service.Mappers;

namespace Historie.Informatie.Service.Profiles;

public class AdresseringBinnenlandInOnderzoekConverter : ITypeConverter<GbaInOnderzoek, AdresseringBinnenlandInOnderzoek?>
{
    public AdresseringBinnenlandInOnderzoek? Convert(GbaInOnderzoek source, AdresseringBinnenlandInOnderzoek? destination, ResolutionContext context)
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
            "081200" or
            "581200" => GroepLocatieInOnderzoek(source),
            "081210" or
            "581210" => LocatiebeschrijvingInOnderzoek(source),
            "089999" or
            "589999" => VastgesteldVerblijftNietOpAdresInOnderzoek(source),
            _ => null
        };
    }

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
using Brp.Shared.DtoMappers.Mappers;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;

namespace Historie.Informatie.Service.Mappers;

public static class AdresseringBuitenlandInOnderzoekConverter
{
    public static AdresseringBuitenlandInOnderzoek? Convert(this GbaInOnderzoek? source)
    {
        if (source is null)
    {
        return null;
    }

    var aanduiding = NormalizeAanduiding(source.AanduidingGegevensInOnderzoek);

    return aanduiding switch
        {
            "080000" => CategorieVerblijfplaatsInOnderzoek(source),
            "081300" => GroepAdresBuitenlandInOnderzoek(source),
            "081310" => LandInOnderzoek(source),
            "081330" => Regel1InOnderzoek(source),
            "081340" => Regel2InOnderzoek(source),
            "081350" => Regel3InOnderzoek(source),
            _ => null
        };
    }

    private static string? NormalizeAanduiding(string? aanduiding) =>
        aanduiding?.StartsWith("58", StringComparison.Ordinal) == true
            ? $"08{aanduiding[2..]}"
            : aanduiding;

     private static AdresseringBuitenlandInOnderzoek? CategorieVerblijfplaatsInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Adresregel1 = true,
            Adresregel2 = true,
            Adresregel3 = true,
            Land = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresseringBuitenlandInOnderzoek? GroepAdresBuitenlandInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Adresregel1 = true,
            Adresregel2 = true,
            Adresregel3 = true,
            Land = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresseringBuitenlandInOnderzoek? LandInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Land = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresseringBuitenlandInOnderzoek? Regel1InOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Adresregel1 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresseringBuitenlandInOnderzoek? Regel2InOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Adresregel2 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresseringBuitenlandInOnderzoek? Regel3InOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Adresregel3 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };
}

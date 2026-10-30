using Brp.Shared.DtoMappers.Mappers;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;

namespace Historie.Informatie.Service.Mappers;

public static class AdresseringBuitenlandInOnderzoekMapper
{
    public static AdresseringBuitenlandInOnderzoek? Convert(this GbaInOnderzoek? source)
    {
                return source?.AanduidingGegevensInOnderzoek switch
        {
            "080000" or
            "580000" => CategorieVerblijfplaatsInOnderzoek(source),
            "081300" or
            "581300" => GroepAdresBuitenlandInOnderzoek(source),
            "081310" or
            "581310" => LandInOnderzoek(source),
            "081330" or
            "581330" => Regel1InOnderzoek(source),
            "081340" or
            "581340" => Regel2InOnderzoek(source),
            "081350" or
            "581350" => Regel3InOnderzoek(source),
            _ => null
        };
    }
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

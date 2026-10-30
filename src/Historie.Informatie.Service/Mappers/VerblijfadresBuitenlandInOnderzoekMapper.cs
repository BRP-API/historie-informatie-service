
using Brp.Shared.DtoMappers.Mappers;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;

namespace Historie.Informatie.Service.Mappers;

public  static class VerblijfadresBuitenlandInOnderzoekMapper
{
    public static VerblijfadresBuitenlandInOnderzoek? Convert(this GbaInOnderzoek? source)
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
     private static VerblijfadresBuitenlandInOnderzoek? CategorieVerblijfplaatsInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Regel1 = true,
            Regel2 = true,
            Regel3 = true,
            Land = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfadresBuitenlandInOnderzoek? GroepAdresBuitenlandInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Regel1 = true,
            Regel2 = true,
            Regel3 = true,
            Land = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfadresBuitenlandInOnderzoek? LandInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Land = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfadresBuitenlandInOnderzoek? Regel1InOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Regel1 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfadresBuitenlandInOnderzoek? Regel2InOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Regel2 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfadresBuitenlandInOnderzoek? Regel3InOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Regel3 = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };
}

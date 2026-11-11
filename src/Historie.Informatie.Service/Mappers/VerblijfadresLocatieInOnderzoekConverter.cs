using Brp.Shared.DtoMappers.Mappers;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;

namespace Historie.Informatie.Service.Mappers;

public static class VerblijfadresLocatieInOnderzoekConverter
{
    public static VerblijfadresLocatieInOnderzoek? Convert(GbaInOnderzoek? source)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "080000" or
            "580000" => CategorieVerblijfplaatsInOnderzoek(source),
            "081200" or
            "581200" => GroepLocatieInOnderzoek(source),
            "081210" or
            "581210" => LocatiebeschrijvingInOnderzoek(source),
            _ => null
        };
    }
       private static VerblijfadresLocatieInOnderzoek CategorieVerblijfplaatsInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Locatiebeschrijving = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfadresLocatieInOnderzoek GroepLocatieInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Locatiebeschrijving = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfadresLocatieInOnderzoek LocatiebeschrijvingInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Locatiebeschrijving = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };
}

using AutoMapper;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;
using Historie.Informatie.Service.Mappers;

namespace Historie.Informatie.Service.Profiles;

public class VerblijfplaatsOnbekendVoorkomenInOnderzoekConverter : ITypeConverter<GbaInOnderzoek, VerblijfplaatsOnbekendVoorkomenInOnderzoek?>
{
    public VerblijfplaatsOnbekendVoorkomenInOnderzoek? Convert(GbaInOnderzoek source, VerblijfplaatsOnbekendVoorkomenInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "080000" or "580000" => CategorieVerblijfplaatsInOnderzoek(source),
            "081300" or "581300" => GroepAdresBuitenlandInOnderzoek(source),
            "081310" or "581310" => LandInOnderzoek(source),
            "081320" or "581320" => DatumAanvangAdresBuitenlandInOnderzoek(source),
            _ => null
        };
    }

    private static VerblijfplaatsOnbekendVoorkomenInOnderzoek CategorieVerblijfplaatsInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            DatumVan = true,
            GemeenteVanInschrijving = true,
            Type = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfplaatsOnbekendVoorkomenInOnderzoek GroepAdresBuitenlandInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            DatumVan = true,
            Type = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfplaatsOnbekendVoorkomenInOnderzoek DatumAanvangAdresBuitenlandInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            DatumVan = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static VerblijfplaatsOnbekendVoorkomenInOnderzoek LandInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Type = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };
}

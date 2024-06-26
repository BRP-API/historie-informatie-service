using AutoMapper;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;
using Historie.Informatie.Service.Mappers;

namespace Historie.Informatie.Service.Profiles;

public class LocatieVoorkomenInOnderzoekConverter : ITypeConverter<GbaInOnderzoek, LocatieVoorkomenInOnderzoek?>
{
    public LocatieVoorkomenInOnderzoek? Convert(GbaInOnderzoek source, LocatieVoorkomenInOnderzoek? destination, ResolutionContext context)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "080000" or
            "580000" => CategorieVerblijfplaatsInOnderzoek(source),
            "080900" or
            "580900" => GroepGemeenteInOnderzoek(source),
            "080910" or
            "580910" => GemeenteVanInschrijvingInOnderzoek(source),
            "081000" or
            "581000" => GroepAdreshoudingInOnderzoek(source),
            "081010" or
            "581010" => FunctieAdresInOnderzoek(source),
            "081030" or
            "581030" => DatumAanvangAdreshoudingInOnderzoek(source),
            "081200" or
            "581200" => GroepLocatieInOnderzoek(source),
            "081210" or
            "581210" => LocatiebeschrijvingInOnderzoek(source),
            _ => null
        };
    }

    private static LocatieVoorkomenInOnderzoek CategorieVerblijfplaatsInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            DatumVan = true,
            FunctieAdres = true,
            GemeenteVanInschrijving = true,
            Type = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static LocatieVoorkomenInOnderzoek GroepAdreshoudingInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            DatumVan = true,
            FunctieAdres = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static LocatieVoorkomenInOnderzoek GroepGemeenteInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            GemeenteVanInschrijving = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static LocatieVoorkomenInOnderzoek GroepLocatieInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Type = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static LocatieVoorkomenInOnderzoek DatumAanvangAdreshoudingInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            DatumVan = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static LocatieVoorkomenInOnderzoek FunctieAdresInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            FunctieAdres = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static LocatieVoorkomenInOnderzoek GemeenteVanInschrijvingInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            GemeenteVanInschrijving = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static LocatieVoorkomenInOnderzoek LocatiebeschrijvingInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Type = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };
}
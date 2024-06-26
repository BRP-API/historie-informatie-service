using HaalCentraal.Generated.InformatieService;
using Historie.Informatie.Service.Generated;

namespace Historie.Informatie.Service.Mappers;

public static class VerblijfplaatsVoorkomenMapper
{
    public static bool HeeftDatumAanvangVolgendeVerblijf(this IBrpVerblijfplaatsVoorkomen voorkomen) =>
        !string.IsNullOrWhiteSpace(voorkomen.DatumAanvangVolgendeAdreshouding) ||
        !string.IsNullOrWhiteSpace(voorkomen.DatumAanvangVolgendeAdresBuitenland);

    public static AbstractDatum? MapDatumTot(this IBrpVerblijfplaatsVoorkomen voorkomen) =>
        voorkomen switch
        {
            { DatumAanvangVolgendeAdresBuitenland: var datum } when !string.IsNullOrWhiteSpace(datum) => datum.Map(),
            { DatumAanvangVolgendeAdreshouding: var datum } when !string.IsNullOrWhiteSpace(datum) => datum.Map(),
            _ => null
        };

    public static AbstractDatum? MapDatumVan(this IBrpVerblijfplaatsVoorkomen voorkomen) =>
        voorkomen switch
        {
            { DatumAanvangAdresBuitenland: var datum } when !string.IsNullOrWhiteSpace(datum) => datum.Map(),
            { DatumAanvangAdreshouding: var datum } when !string.IsNullOrWhiteSpace(datum) => datum.Map(),
            _ => null
        };

    public static AbstractDatum? MapVerblijftNietOpAdres(this IBrpVerblijfplaatsVoorkomen voorkomen)
    {
        if (voorkomen.InOnderzoek.IsVastgesteldVerblijftNietOpAdres() &&
            !voorkomen.InOnderzoekVolgendeVerblijfplaats.IsBeëindigdOpOfNa(new[]
            {
                voorkomen.DatumAanvangVolgendeAdreshouding,
                voorkomen.DatumAanvangVolgendeAdresBuitenland
            }))
        {
            return voorkomen.InOnderzoek!.DatumIngangOnderzoek.Map();
        }

        return null;
    }

    private static bool IsVastgesteldVerblijftNietOpAdres(this IBrpInOnderzoek? inOnderzoek) =>
        inOnderzoek != null &&
        new[] { "089999", "589999" }.Contains(inOnderzoek.AanduidingGegevensInOnderzoek);

    private static bool IsBeëindigdOpOfNa(this IBrpInOnderzoek? inOnderzoek, string?[] datums)
    {
        if(inOnderzoek == null) return false;

        foreach(var datum in datums)
        {
            if(datum != null && int.Parse(inOnderzoek.DatumIngangOnderzoek) < int.Parse(datum))
            {
                return false;
            }
        }
        return true;
    }
}

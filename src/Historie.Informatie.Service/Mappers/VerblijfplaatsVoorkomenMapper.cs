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

    public static bool IsVastgesteldVerblijftNietOpAdres(this IBrpInOnderzoek? inOnderzoek,
                                                         string? datumAanvangVolgendeAdreshouding,
                                                         string? datumAanvangVolgendeAdresBuitenland) =>
        inOnderzoek != null &&
        new[] { "089999", "589999" }.Contains(inOnderzoek.AanduidingGegevensInOnderzoek) &&
                (string.IsNullOrEmpty(inOnderzoek.DatumEindeOnderzoek) ||
                inOnderzoek.DatumEindeOnderzoek.ValtOpOfNa(datumAanvangVolgendeAdreshouding, datumAanvangVolgendeAdresBuitenland));

    private static bool ValtOpOfNa(this string datumEinde,
                                   string? datumAanvangVolgendeAdreshouding,
                                   string? datumAanvangVolgendeAdresBuitenland)
    {
        if (!string.IsNullOrEmpty(datumEinde) && string.IsNullOrEmpty(datumAanvangVolgendeAdreshouding) && string.IsNullOrEmpty(datumAanvangVolgendeAdresBuitenland)) return false;

        if (datumAanvangVolgendeAdreshouding != null && int.Parse(datumEinde) < int.Parse(datumAanvangVolgendeAdreshouding)) return false;

        if (datumAanvangVolgendeAdresBuitenland != null && int.Parse(datumEinde) < int.Parse(datumAanvangVolgendeAdresBuitenland)) return false;

        return true;
    }
}

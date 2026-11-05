using Brp.Shared.DtoMappers.BrpApiDtos;
using Historie.Informatie.Service.Generated;
using Brp.Shared.DtoMappers.Mappers;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;

namespace Historie.Informatie.Service.Mappers;

public static class VerblijfplaatsVoorkomenMapper
{

    public static AbstractVerblijfplaatsVoorkomen? MapVoorkomen(this GbaVerblijfplaatsVoorkomen? voorkomen)
    {
        if (voorkomen is null) return null;

        if (voorkomen.Land?.Code == "0000")
            return VerblijfplaatsOnbekendVoorkomenMapper.Map(voorkomen);

        if (voorkomen.Land is not null)
        {
            return VerblijfplaatsBuitenlandVoorkomenMapper.Map(voorkomen);
        }

        if (!string.IsNullOrWhiteSpace(voorkomen.Straat))
        {
           return AdresVoorkomenMapper.Map(voorkomen);
        }

        if (!string.IsNullOrWhiteSpace(voorkomen.Locatiebeschrijving))
        {
            return LocatieVoorkomenMapper.Map(voorkomen);
        }

        return null;
    }
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

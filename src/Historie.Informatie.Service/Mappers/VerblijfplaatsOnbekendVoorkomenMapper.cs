using Brp.Shared.DtoMappers.Mappers;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;

namespace Historie.Informatie.Service.Mappers;

public static class VerblijfplaatsOnbekendVoorkomenMapper
{
    public static VerblijfplaatsOnbekendVoorkomen? Map(this GbaVerblijfplaatsVoorkomen source)
    {
        if (source is null)
            return null;

        var onbekendVoorkomen = new VerblijfplaatsOnbekendVoorkomen
        {
            DatumVan = source.MapDatumVan(),
            DatumTot = source.HeeftDatumAanvangVolgendeVerblijf()
                ? source.MapDatumTot()
                : null,
            GemeenteVanInschrijving = source.GemeenteVanInschrijving,
            Rni = source.Rni?.Map(),
            InOnderzoek = MapInOnderzoek(source.InOnderzoek)
        };

        onbekendVoorkomen.InOnderzoek =
            source.InOnderzoekVolgendeVerblijfplaats
                .ConvertDatumAanvangVolgendeVerblijfplaatsInOnderzoek(
                    onbekendVoorkomen.InOnderzoek);

        return onbekendVoorkomen;
    }

    private static VerblijfplaatsOnbekendVoorkomenInOnderzoek? MapInOnderzoek(
        GbaInOnderzoek? source)
    {
        return source?.AanduidingGegevensInOnderzoek switch
        {
            "080000" or "580000" => new()
            {
                DatumVan = true,
                GemeenteVanInschrijving = true,
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek?.Map()
            },
            "081300" or "581300" => new()
            {
                DatumVan = true,
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek?.Map()
            },
            "081310" or "581310" => new()
            {
                Type = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek?.Map()
            },
            "081320" or "581320" => new()
            {
                DatumVan = true,
                DatumIngangOnderzoek = source.DatumIngangOnderzoek?.Map()
            },
            _ => null
        };
    }
}

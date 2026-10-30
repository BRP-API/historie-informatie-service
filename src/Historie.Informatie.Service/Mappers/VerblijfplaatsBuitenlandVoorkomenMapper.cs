using Brp.Shared.DtoMappers.Mappers;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;

namespace Historie.Informatie.Service.Mappers;

public static class VerblijfplaatsBuitenlandVoorkomenMapper
{
    public static VerblijfplaatsBuitenlandVoorkomen? Map(this GbaVerblijfplaatsVoorkomen? source)
    {
        if (source is null)
            return null;

        var buitenlandVoorkomen = new VerblijfplaatsBuitenlandVoorkomen
        {
            DatumVan = source.DatumAanvangAdresBuitenland.Map(),
            DatumTot = source.HeeftDatumAanvangVolgendeVerblijf()
                ? source.MapDatumTot()
                : null,
            Rni = source.Rni?.Map(),
            GemeenteVanInschrijving = source.GemeenteVanInschrijving,
            Verblijfadres = new VerblijfadresBuitenland
            {
                Regel1 = source.Regel1,
                Regel2 = source.Regel2,
                Regel3 = source.Regel3,
                Land = source.Land,
                InOnderzoek =
                    VerblijfadresBuitenlandInOnderzoekMapper.Convert(
                        source.InOnderzoek)
            },
            Adressering = new AdresseringBuitenland
            {
                Adresregel1 = source.Adresregel1(),
                Adresregel2 = source.Adresregel2(source.GemeenteVanInschrijving),
                Adresregel3 = source.Adresregel3(),
                Land = source.Land(),
                InOnderzoek =
                    AdresseringBuitenlandInOnderzoekMapper.Convert(
                        source.InOnderzoek)
            },
            InOnderzoek = source.InOnderzoek.ToVerblijfplaatsBuitenlandVoorkomenInOnderzoek()
        };

        buitenlandVoorkomen.InOnderzoek =
            source.InOnderzoekVolgendeVerblijfplaats
                .ConvertDatumAanvangVolgendeVerblijfplaatsInOnderzoek(
                    buitenlandVoorkomen.InOnderzoek);

        return buitenlandVoorkomen;
    }
}

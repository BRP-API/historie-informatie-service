using Brp.Shared.DtoMappers.Mappers;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;

namespace Historie.Informatie.Service.Mappers;

public static class LocatieVoorkomenMapper
{
    public static LocatieVoorkomen? Map(GbaVerblijfplaatsVoorkomen source)
    {
       if (source is null)
        {
            return null;
        }

        var locatieVoorkomen = new LocatieVoorkomen
        {
            DatumVan = source.DatumAanvangAdreshouding?.Map(),
            DatumTot = source.HeeftDatumAanvangVolgendeVerblijf()
                ? source.MapDatumTot()
                : null,
            FunctieAdres = source.FunctieAdres,
            Verblijfadres = new VerblijfadresLocatie
            {
                Locatiebeschrijving = source.Locatiebeschrijving,
                InOnderzoek =
                    VerblijfadresLocatieInOnderzoekConverter.Convert(source.InOnderzoek)
            },
            GemeenteVanInschrijving = source.GemeenteVanInschrijving,
            InOnderzoek = LocatieVoorkomenInOnderzoekConverter.Convert(source.InOnderzoek),
            Adressering = new AdresseringBinnenland
            {
                Adresregel1 = source.Adresregel1(),
                Adresregel2 = source.Adresregel2(
                    source.GemeenteVanInschrijving),
                InOnderzoek =
                    AdresseringBinnenlandInOnderzoekConverter.Convert(source.InOnderzoek)
            }
        };

        locatieVoorkomen.InOnderzoek =
            source.InOnderzoekVolgendeVerblijfplaats
                .ConvertDatumAanvangVolgendeVerblijfplaatsInOnderzoek(
                    locatieVoorkomen.InOnderzoek);

        return locatieVoorkomen;
    }
}

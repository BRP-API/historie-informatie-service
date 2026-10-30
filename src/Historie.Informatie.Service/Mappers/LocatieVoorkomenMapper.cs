using Brp.Shared.DtoMappers.Mappers;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;

namespace Historie.Informatie.Service.Mappers;

public class LocatieVoorkomenMapper
{
    public static LocatieVoorkomen Map(HaalCentraal.Generated.DataService.GbaVerblijfplaatsVoorkomen source)
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
                    VerblijfadresLocatieInOnderzoekMapper.Map(source.InOnderzoek)
            },
            GemeenteVanInschrijving = source.GemeenteVanInschrijving,
            InOnderzoek = LocatieVoorkomenInOnderzoekMapper.Map(source.InOnderzoek),
            Adressering = new AdresseringBinnenland
            {
                Adresregel1 = source.Adresregel1(),
                Adresregel2 = source.Adresregel2(
                    source.GemeenteVanInschrijving),
                InOnderzoek =
                    AdresseringBinnenlandInOnderzoekMapper.Map(source.InOnderzoek)
            }
        };

        locatieVoorkomen.InOnderzoek =
            source.InOnderzoekVolgendeVerblijfplaats
                .ConvertDatumAanvangVolgendeVerblijfplaatsInOnderzoek(
                    locatieVoorkomen.InOnderzoek);

        return locatieVoorkomen;
    }
}

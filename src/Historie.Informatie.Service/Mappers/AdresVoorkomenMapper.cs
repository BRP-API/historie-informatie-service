using Brp.Shared.DtoMappers.Mappers;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;
namespace Historie.Informatie.Service.Mappers;

public class AdresVoorkomenMapper
{
    public static AdresVoorkomen? Map(GbaVerblijfplaatsVoorkomen? source)
    {
        if (source is null)
        {
            return null;
        }

        var adresVoorkomen = new AdresVoorkomen
        {
            Adressering = new AdresseringBinnenland
            {
                Adresregel1 = source.Adresregel1(),
                Adresregel2 = source.Adresregel2(source.GemeenteVanInschrijving),
                InOnderzoek = AdresseringBinnenlandInOnderzoekMapper.Map(source.InOnderzoek)
            },
            Verblijfadres = new VerblijfadresBinnenland
            {
                KorteStraatnaam = source.Straat != "." ? source.Straat : null,
                Huisnummer = source.Huisnummer is not 0 ? source.Huisnummer : null,
                OfficieleStraatnaam = source.NaamOpenbareRuimte,
                Huisletter = source.Huisletter,
                Huisnummertoevoeging = source.Huisnummertoevoeging,
                AanduidingBijHuisnummer = source.AanduidingBijHuisnummer,
                Postcode = source.Postcode,
                Woonplaats = source.Woonplaats,
                InOnderzoek = VerblijfadresBinnenlandInOnderzoekMapper.Map(source.InOnderzoek)
            },
            FunctieAdres = source.FunctieAdres,
            AdresseerbaarObjectIdentificatie = source.AdresseerbaarObjectIdentificatie,
            NummeraanduidingIdentificatie = source.NummeraanduidingIdentificatie,
            GemeenteVanInschrijving = source.GemeenteVanInschrijving,
            DatumVan = source.DatumAanvangAdreshouding?.Map(),
            DatumTot = source.HeeftDatumAanvangVolgendeVerblijf()
                ? source.MapDatumTot()
                : null,
            VerblijftNietOpAdresVanaf =
                source.InOnderzoek.IsVastgesteldVerblijftNietOpAdres(
                    source.DatumAanvangVolgendeAdreshouding,
                    source.DatumAanvangVolgendeAdresBuitenland)
                    ? source.InOnderzoek?.DatumIngangOnderzoek?.Map()
                    : null,
            InOnderzoek = AdresVoorkomenInOnderzoekMapper.Map(source.InOnderzoek)
        };
  adresVoorkomen.InOnderzoek =
            source.InOnderzoekVolgendeVerblijfplaats
                .ConvertDatumAanvangVolgendeVerblijfplaatsInOnderzoek(
                    adresVoorkomen.InOnderzoek);

        if (source.InOnderzoek is
                { AanduidingGegevensInOnderzoek: "089999" or "589999" } &&
            (adresVoorkomen.VerblijftNietOpAdresVanaf is null ||
             source.InOnderzoek.DatumEindeOnderzoek is not null))
        {
            adresVoorkomen.InOnderzoek = null;
            adresVoorkomen.Verblijfadres.InOnderzoek = null;
            adresVoorkomen.Adressering.InOnderzoek = null;
        }

        return adresVoorkomen;
    }
}
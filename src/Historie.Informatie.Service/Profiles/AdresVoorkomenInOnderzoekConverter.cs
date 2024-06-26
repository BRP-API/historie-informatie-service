using AutoMapper;
using HaalCentraal.Generated.DataService;
using HaalCentraal.Generated.InformatieService;
using Historie.Informatie.Service.Mappers;

namespace Historie.Informatie.Service.Profiles;

public class AdresVoorkomenInOnderzoekConverter : ITypeConverter<GbaInOnderzoek, AdresVoorkomenInOnderzoek?>
{
    public AdresVoorkomenInOnderzoek? Convert(GbaInOnderzoek source, AdresVoorkomenInOnderzoek? destination, ResolutionContext context)
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
            "081100" or
            "581100" => GroepAdresInOnderzoek(source),
            "081110" or 
            "581110" => StraatnaamInOnderzoek(source),
            "081180" or
            "581180" => IdentificatiecodeVerblijfplaatsInOnderzoek(source),
            "081190" or
            "581190" => IdentificatiecodeNummeraanduidingInOnderzoek(source),
            "089999" or
            "589999" => VastgesteldVerblijftNietOpAdresInOnderzoek(source),
            _ => null
        };
    }

    private static AdresVoorkomenInOnderzoek CategorieVerblijfplaatsInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            AdresseerbaarObjectIdentificatie = true,
            DatumVan = true,
            FunctieAdres = true,
            NummeraanduidingIdentificatie = true,
            GemeenteVanInschrijving = true,
            Type = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresVoorkomenInOnderzoek DatumAanvangAdreshoudingInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            DatumVan = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresVoorkomenInOnderzoek FunctieAdresInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            FunctieAdres = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresVoorkomenInOnderzoek GemeenteVanInschrijvingInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            GemeenteVanInschrijving = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresVoorkomenInOnderzoek GroepAdresInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            AdresseerbaarObjectIdentificatie = true,
            NummeraanduidingIdentificatie = true,
            Type = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresVoorkomenInOnderzoek GroepAdreshoudingInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            DatumVan = true,
            FunctieAdres = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresVoorkomenInOnderzoek GroepGemeenteInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            GemeenteVanInschrijving = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresVoorkomenInOnderzoek IdentificatiecodeNummeraanduidingInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            NummeraanduidingIdentificatie = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresVoorkomenInOnderzoek IdentificatiecodeVerblijfplaatsInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            AdresseerbaarObjectIdentificatie = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresVoorkomenInOnderzoek StraatnaamInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            Type = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };

    private static AdresVoorkomenInOnderzoek VastgesteldVerblijftNietOpAdresInOnderzoek(GbaInOnderzoek source) =>
        new()
        {
            AdresseerbaarObjectIdentificatie = true,
            DatumVan = true,
            FunctieAdres = true,
            NummeraanduidingIdentificatie = true,
            GemeenteVanInschrijving = true,
            Type = true,
            DatumIngangOnderzoek = source?.DatumIngangOnderzoek.Map()
        };
}
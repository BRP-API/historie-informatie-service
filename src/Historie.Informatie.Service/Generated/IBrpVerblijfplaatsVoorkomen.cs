namespace Historie.Informatie.Service.Generated;

public interface IBrpVerblijfplaatsVoorkomen
{
    string? DatumAanvangAdresBuitenland { get; }
    string? DatumAanvangAdreshouding { get; }

    string? DatumAanvangVolgendeAdresBuitenland { get; }
    string? DatumAanvangVolgendeAdreshouding { get; }

    string? Straat { get; }
    int? Huisnummer { get; }
    string? Huisletter { get; }
    Brp.Shared.DtoMappers.Interfaces.IWaardetabel AanduidingBijHuisnummer { get; }
    string? Huisnummertoevoeging { get; }
    Brp.Shared.DtoMappers.Interfaces.IWaardetabel GemeenteVanInschrijving { get; }
    string? Postcode { get; }
    string? Woonplaats { get; }

    string? Locatiebeschrijving { get; }

    Brp.Shared.DtoMappers.Interfaces.IWaardetabel Land { get; }
    string? Regel1 { get; }
    string? Regel2 { get; }
    string? Regel3 { get; }

    IBrpInOnderzoek? InOnderzoek { get; }
    IBrpInOnderzoek? InOnderzoekVolgendeVerblijfplaats { get; }
}

using HaalCentraal.Generated.InformatieService;
using Historie.Informatie.Service.Generated;
using System.Text;
using System.Text.RegularExpressions;

namespace Historie.Informatie.Service.Mappers;

public static class AdresregelsMapper
{
    public static string? Adresregel1(this IBrpVerblijfplaatsVoorkomen verblijfplaats)
    {
        if (verblijfplaats == null) return null;

        if (verblijfplaats.IsAdres()) return verblijfplaats.ConstructAdresregel1FromAdres();

        if (verblijfplaats.IsLocatie()) return verblijfplaats.ConstructAdresregel1FromLocatie();

        if (verblijfplaats.IsVerblijfplaatsBuitenland()) return verblijfplaats.ConstructAdresregel1FromVerblijfplaatsBuitenland();

        return null;
    }

    public static string? Adresregel2(this IBrpVerblijfplaatsVoorkomen verblijfplaats, IWaardetabel gemeenteVanInschrijving)
    {
        if (verblijfplaats == null) return null;

        if (verblijfplaats.IsAdres()) return verblijfplaats.ConstructAdresregel2FromAdres(gemeenteVanInschrijving);

        if (verblijfplaats.IsLocatie()) return verblijfplaats.ConstructAdresregel2FromLocatie(gemeenteVanInschrijving);

        if (verblijfplaats.IsVerblijfplaatsBuitenland()) return verblijfplaats.ConstructAdresregel2FromVerblijfplaatsBuitenland();

        return null;
    }

    private static bool StraatHeeftStandaardWaarde(this IBrpVerblijfplaatsVoorkomen verblijfplaats) =>
        string.IsNullOrWhiteSpace(verblijfplaats.Straat) || verblijfplaats.Straat == ".";
    private static bool HuisnummerHeeftStandaardWaarde(this IBrpVerblijfplaatsVoorkomen verblijfplaats) =>
        verblijfplaats.Huisnummer == 0;
    private static bool LandHeeftStandaardWaarde(this IBrpVerblijfplaatsVoorkomen verblijfplaats) =>
        verblijfplaats.Land == null || verblijfplaats.Land.Code == "0000";
    private static bool RegelsHebbenStandaardWaarde(this IBrpVerblijfplaatsVoorkomen verblijfplaats) =>
        string.IsNullOrWhiteSpace(verblijfplaats.Regel1) &&
        string.IsNullOrWhiteSpace(verblijfplaats.Regel2) &&
        string.IsNullOrWhiteSpace(verblijfplaats.Regel3);

    private static bool IsAdres(this IBrpVerblijfplaatsVoorkomen verblijfplaats) =>
        !verblijfplaats.StraatHeeftStandaardWaarde() && !verblijfplaats.HuisnummerHeeftStandaardWaarde();
    private static bool IsLocatie(this IBrpVerblijfplaatsVoorkomen verblijfplaats) =>
        !string.IsNullOrWhiteSpace(verblijfplaats.Locatiebeschrijving);
    private static bool IsVerblijfplaatsBuitenland(this IBrpVerblijfplaatsVoorkomen verblijfplaats) =>
        !string.IsNullOrWhiteSpace(verblijfplaats.Land?.Code);

    private static string? ConstructAdresregel1FromAdres(this IBrpVerblijfplaatsVoorkomen verblijfplaats)
    {
        StringBuilder retval = new();

        retval.AppendStraat(verblijfplaats);
        retval.AppendAanduidingBijHuisnummer(verblijfplaats);
        retval.AppendHuisnummer(verblijfplaats);
        retval.AppendHuisletter(verblijfplaats);
        retval.AppendHuisnummertoevoeging(verblijfplaats);

        return retval.ToString();
    }

    private static string? ConstructAdresregel1FromLocatie(this IBrpVerblijfplaatsVoorkomen verblijfplaats)
    {
        return verblijfplaats.Locatiebeschrijving;
    }

    private static string? ConstructAdresregel1FromVerblijfplaatsBuitenland(this IBrpVerblijfplaatsVoorkomen verblijfplaats)
    {
        return verblijfplaats.LandHeeftStandaardWaarde() ||
            verblijfplaats.RegelsHebbenStandaardWaarde()
            ? null
            : verblijfplaats.Regel1;
    }

    private static void AppendStraat(this StringBuilder target, IBrpVerblijfplaatsVoorkomen adres)
    {
        if (string.IsNullOrWhiteSpace(adres.Straat)) return;

        target.Append(adres.Straat);
    }

    private static void AppendAanduidingBijHuisnummer(this StringBuilder target, IBrpVerblijfplaatsVoorkomen adres)
    {
        switch (adres.AanduidingBijHuisnummer?.Code)
        {
            case "to":
                target.Append(" t/o");
                break;
            case "by":
                target.Append(" bij");
                break;
            default:
                break;
        }
    }

    private static void AppendHuisnummer(this StringBuilder target, IBrpVerblijfplaatsVoorkomen adres)
    {
        if (!adres.Huisnummer.HasValue) return;

        target.AppendFormat("{1}{0}", adres.Huisnummer, target.Length > 0 ? " " : "");
    }

    private static void AppendHuisletter(this StringBuilder target, IBrpVerblijfplaatsVoorkomen adres)
    {
        if (string.IsNullOrWhiteSpace(adres.Huisletter)) return;

        target.AppendFormat(" {0}", adres.Huisletter);
    }

    private static bool BegintMetCijfer(this string input) =>
        Regex.Match(input, @"^\d.*$", RegexOptions.None, TimeSpan.FromMilliseconds(100)).Success;

    private static void AppendHuisnummertoevoeging(this StringBuilder retval, IBrpVerblijfplaatsVoorkomen adres)
    {
        if (string.IsNullOrWhiteSpace(adres.Huisnummertoevoeging)) return;

        if (string.IsNullOrWhiteSpace(adres.Huisletter))
        {
            retval.Append(adres.Huisnummertoevoeging.BegintMetCijfer() ? "-" : " ");
        }
        retval.Append(adres.Huisnummertoevoeging);
    }

    private static string? ConstructAdresregel2FromAdres(this IBrpVerblijfplaatsVoorkomen adres, IWaardetabel gemeenteVanInschrijving)
    {
        if (string.IsNullOrWhiteSpace(adres.Postcode)) return null;

        var postcodeNum = adres.Postcode != null ? adres.Postcode[0..4] : String.Empty;
        var postcodeAlfa = adres.Postcode != null ? adres.Postcode[4..] : String.Empty;

        return !string.IsNullOrWhiteSpace(adres.Woonplaats)
            ? $"{postcodeNum} {postcodeAlfa}  {adres.Woonplaats.ToUpperInvariant()}"
            : $"{postcodeNum} {postcodeAlfa}  {gemeenteVanInschrijving.Omschrijving?.ToUpperInvariant()}";
    }

    private static string? ConstructAdresregel2FromLocatie(this IBrpVerblijfplaatsVoorkomen _, IWaardetabel gemeenteVanInschrijving)
    {
        return gemeenteVanInschrijving?.Omschrijving.ToUpperInvariant();
    }

    private static string? ConstructAdresregel2FromVerblijfplaatsBuitenland(this IBrpVerblijfplaatsVoorkomen verblijfplaats)
    {
        return verblijfplaats.LandHeeftStandaardWaarde() ||
            verblijfplaats.RegelsHebbenStandaardWaarde()
                ? null
                : verblijfplaats.Regel2;
    }

    public static string? Adresregel3(this IBrpVerblijfplaatsVoorkomen verblijfplaats)
    {
        return verblijfplaats == null ||
            verblijfplaats.LandHeeftStandaardWaarde() ||
            verblijfplaats.RegelsHebbenStandaardWaarde()
            ? null
            : verblijfplaats.Regel3;
    }

    public static Waardetabel? Land(this IBrpVerblijfplaatsVoorkomen verblijfplaats)
    {
        return verblijfplaats == null ||
            verblijfplaats.LandHeeftStandaardWaarde() ||
            verblijfplaats.RegelsHebbenStandaardWaarde()
            ? null
            : new Waardetabel
            {
                Code = verblijfplaats.Land.Code,
                Omschrijving = verblijfplaats.Land.Omschrijving
            };
    }
}

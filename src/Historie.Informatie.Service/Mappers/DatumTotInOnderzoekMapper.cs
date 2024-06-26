using HaalCentraal.Generated.DataService;
using Historie.Informatie.Service.Generated;

namespace Historie.Informatie.Service.Mappers;

public static class DatumTotInOnderzoekMapper
{
    public static T MapDatumAanvangVolgendeVerblijfplaatsInOnderzoek<T>(this GbaInOnderzoek? inOnderzoekVolgendeVerblijfplaats, T inOnderzoek) where T: IAbstractVerblijfplaatsVoorkomenInOnderzoek, new()
    {
        switch(inOnderzoekVolgendeVerblijfplaats?.AanduidingGegevensInOnderzoek.PadLeft(6, '0'))
        {
            case "080000":
            case "580000":
            case "081000":
            case "581000":
            case "081030":
            case "581030":
            case "081300":
            case "581300":
            case "081320":
            case "581320":
                inOnderzoek ??= new T()
                {
                    DatumIngangOnderzoek = inOnderzoekVolgendeVerblijfplaats.DatumIngangOnderzoek.Map()
                };
                inOnderzoek.DatumTot = true;
                break;
            default:
                break;
        }
        return inOnderzoek;
    }
}

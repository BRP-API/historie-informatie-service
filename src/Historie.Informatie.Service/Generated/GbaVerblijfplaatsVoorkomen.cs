using Historie.Informatie.Service.Generated;

namespace HaalCentraal.Generated.DataService;

public partial class GbaVerblijfplaatsVoorkomen : IBrpVerblijfplaatsVoorkomen
{
    IWaardetabel IBrpVerblijfplaatsVoorkomen.GemeenteVanInschrijving => this.GemeenteVanInschrijving;

    IWaardetabel IBrpVerblijfplaatsVoorkomen.AanduidingBijHuisnummer => this.AanduidingBijHuisnummer;

    IWaardetabel IBrpVerblijfplaatsVoorkomen.Land => this.Land;

    IBrpInOnderzoek IBrpVerblijfplaatsVoorkomen.InOnderzoek => this.InOnderzoek;

    IBrpInOnderzoek IBrpVerblijfplaatsVoorkomen.InOnderzoekVolgendeVerblijfplaats => this.InOnderzoekVolgendeVerblijfplaats;
}

using Historie.Informatie.Service.Generated;

namespace HaalCentraal.Generated.DataService;

public partial class GbaVerblijfplaatsVoorkomen : IBrpVerblijfplaatsVoorkomen
{
    Brp.Shared.DtoMappers.Interfaces.IWaardetabel IBrpVerblijfplaatsVoorkomen.GemeenteVanInschrijving => this.GemeenteVanInschrijving;

    Brp.Shared.DtoMappers.Interfaces.IWaardetabel IBrpVerblijfplaatsVoorkomen.AanduidingBijHuisnummer => this.AanduidingBijHuisnummer;

    Brp.Shared.DtoMappers.Interfaces.IWaardetabel IBrpVerblijfplaatsVoorkomen.Land => this.Land;

    IBrpInOnderzoek IBrpVerblijfplaatsVoorkomen.InOnderzoek => this.InOnderzoek;

    IBrpInOnderzoek IBrpVerblijfplaatsVoorkomen.InOnderzoekVolgendeVerblijfplaats => this.InOnderzoekVolgendeVerblijfplaats;
}

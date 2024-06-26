using Historie.Informatie.Service.Generated;

namespace HaalCentraal.Generated.InformatieService;

public partial class AdresVoorkomen : IAbstractVerblijfplaatsVoorkomen
{
    IAbstractVerblijfplaatsVoorkomenInOnderzoek IAbstractVerblijfplaatsVoorkomen.InOnderzoek
    {
        get { return this.InOnderzoek; }
        set { this.InOnderzoek = (AdresVoorkomenInOnderzoek)value; }
    }
}

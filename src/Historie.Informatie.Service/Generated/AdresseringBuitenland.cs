namespace HaalCentraal.Generated.InformatieService;

public partial class AdresseringBuitenland
{
    public bool ShouldSerialize() =>
        !string.IsNullOrWhiteSpace(Adresregel1) ||
        !string.IsNullOrWhiteSpace(Adresregel2) ||
        !string.IsNullOrWhiteSpace(Adresregel3) ||
        Land != null
        ;
}

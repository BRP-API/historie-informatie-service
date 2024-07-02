namespace HaalCentraal.Generated.InformatieService;

public partial class AdresseringBinnenland
{
    public bool ShouldSerialize() =>
        !string.IsNullOrWhiteSpace(Adresregel1) ||
        !string.IsNullOrWhiteSpace(Adresregel2)
        ;
}

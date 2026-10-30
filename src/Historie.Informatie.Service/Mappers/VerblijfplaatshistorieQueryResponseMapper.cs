using Src = HaalCentraal.Generated.DataService;
using Trg = HaalCentraal.Generated.InformatieService;

namespace Historie.Informatie.Service.Mappers;

public static class VerblijfplaatshistorieQueryResponseMapper
{
     public static Trg.VerblijfplaatshistorieQueryResponse? Map(
        this Src.VerblijfplaatshistorieQueryResponse? source)
    {
        if (source is null)
            return null;

        return new Trg.VerblijfplaatshistorieQueryResponse
        {
            Verblijfplaatsen = source.Verblijfplaatsen?
                .Select(item => item.MapVoorkomen())
                .OfType<Trg.AbstractVerblijfplaatsVoorkomen>()
                .ToList(),

            OpschortingBijhouding = source.OpschortingBijhouding?.Map(),

            GeheimhoudingPersoonsgegevens =
                source.GeheimhoudingPersoonsgegevens is int flag
                    ? flag != 0
                    : null
        };
    }
}

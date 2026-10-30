using Brp.Shared.DtoMappers.Mappers;
using Brp.Shared.DtoMappers.BrpApiDtos;
using HaalCentraal.Generated.DataService;

namespace Historie.Informatie.Service.Mappers;

public static class OpschortingBijhoudingMapper
{
    public static OpschortingBijhouding? Map(this GbaOpschortingBijhouding? source)
    {
        if (source is null)
            return null;

        return new OpschortingBijhouding
        {
            Datum = source.Datum?.Map(),
            Reden = source.Reden is null
                ? null
                : source.Reden.Map()
        };
    }
}
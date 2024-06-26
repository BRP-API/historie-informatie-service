using AutoMapper;
using Brp.Shared.Infrastructure.Json;
using Newtonsoft.Json;
using Src = HaalCentraal.Generated.DataService;
using Trg = HaalCentraal.Generated.InformatieService;

namespace Historie.Informatie.Service.Helpers;

public static class TransformHelpers
{
    public static string Transform(this string payload, IMapper mapper)
    {
        var response = JsonConvert.DeserializeObject<Src.VerblijfplaatshistorieQueryResponse>(payload);

        var retval = mapper.Map<Trg.VerblijfplaatshistorieQueryResponse>(response);

        return retval.ToJsonCompact();
    }
}

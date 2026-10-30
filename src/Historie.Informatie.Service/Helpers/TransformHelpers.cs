//using AutoMapper;
using Brp.Shared.Infrastructure.Json;
using Historie.Informatie.Service.Mappers;
using Newtonsoft.Json;
using HaalCentraal.Generated.DataService;

namespace Historie.Informatie.Service.Helpers;

public static class TransformHelpers
{
    public static string Transform(this string payload)
    {
        var response = JsonConvert.DeserializeObject<VerblijfplaatshistorieQueryResponse>(payload);

        var retval = response.Map();
        //afstemmen met het onderstaande correct is
           return retval is null
            ? "null"
            : retval.ToJsonCompact();
    }
}

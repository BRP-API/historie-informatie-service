using AutoMapper;
using Historie.Data.Mock.Generated;
using Historie.Data.Mock.Entities;
using Historie.Data.Mock.Extensions;
using Historie.Data.Mock.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Historie.Data.Mock.Controllers;

[ApiController]
public class HistorieController : Historie.Data.Mock.Generated.ControllerBase
{
    private readonly PersoonRepository _repository;
    private readonly IMapper _mapper;

    public HistorieController(PersoonRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public override async Task<ActionResult<VerblijfplaatshistorieQueryResponse>> Verblijfplaatshistorie([FromBody] HistorieQuery body)
    {
        var retval = body switch
        {
            RaadpleegMetPeildatum q => await Handle(q),
            RaadpleegMetPeriode q => await Handle(q),
            _ => new VerblijfplaatshistorieQueryResponse()
        };

        return Ok(retval);
    }

    private async Task<VerblijfplaatshistorieQueryResponse> Handle(RaadpleegMetPeildatum q)
    {
        RaadpleegMetPeriode filter = new()
        {
            Burgerservicenummer = q.Burgerservicenummer,
            DatumVan = q.Peildatum,
            DatumTot = q.Peildatum!.ToDateTimeOffset().AddDays(1).ToString("yyyy-MM-dd"),
        };
        var personen = await _repository.Zoek<RaadpleegMetPeriode>(filter);

        return new VerblijfplaatshistorieQueryResponse
        {
            Verblijfplaatsen = personen.ToVerblijfplaatsVoorkomens(_mapper)
        };
    }

    private async Task<VerblijfplaatshistorieQueryResponse> Handle(RaadpleegMetPeriode q)
    {
        var personen = await _repository.Zoek<RaadpleegMetPeriode>(q);


        return new VerblijfplaatshistorieQueryResponse
        {
            Verblijfplaatsen = personen.ToVerblijfplaatsVoorkomens(_mapper)
        };
    }
}

public static class VerblijfplaatsVoorkomenMappers
{
    public static List<GbaVerblijfplaatsVoorkomen> ToVerblijfplaatsVoorkomens(this ICollection<Persoon>? personen, IMapper mapper)
    {
        var retval = new List<GbaVerblijfplaatsVoorkomen>();

        if (personen == null) return retval;

        foreach (var persoon in personen)
        {
            var verblijfplaats = persoon?.Verblijfplaats;
            if (verblijfplaats != null)
            {
                retval.Add(mapper.Map<GbaVerblijfplaatsVoorkomen>(verblijfplaats));
            }
        }

        return retval;
    }
}

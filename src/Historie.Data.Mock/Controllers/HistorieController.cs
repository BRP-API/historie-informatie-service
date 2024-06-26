using HaalCentraal.Generated.DataService;
using Microsoft.AspNetCore.Mvc;

namespace Historie.Data.Mock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistorieController : HaalCentraal.Generated.DataService.ControllerBase
    {
        public override Task<ActionResult<VerblijfplaatshistorieQueryResponse>> Verblijfplaatshistorie([FromBody] HistorieQuery body)
        {
            throw new NotImplementedException();
        }
    }
}

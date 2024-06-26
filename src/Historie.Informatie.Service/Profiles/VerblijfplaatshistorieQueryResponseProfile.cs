using AutoMapper;
using Src = HaalCentraal.Generated.DataService;
using Trg = HaalCentraal.Generated.InformatieService;

namespace Historie.Informatie.Service.Profiles;

public class VerblijfplaatshistorieQueryResponseProfile : Profile
{
    public VerblijfplaatshistorieQueryResponseProfile()
    {
        CreateMap<Src.VerblijfplaatshistorieQueryResponse, Trg.VerblijfplaatshistorieQueryResponse>();
    }
}

using AutoMapper;
using Src = HaalCentraal.Generated.DataService;
using Trg = HaalCentraal.Generated.InformatieService;

namespace Historie.Informatie.Service.Profiles;

public class VerblijfplaatsVoorkomenProfile : Profile
{
    public VerblijfplaatsVoorkomenProfile()
    {
        CreateMap<Src.GbaVerblijfplaatsVoorkomen, Trg.AbstractVerblijfplaatsVoorkomen?>()
            .ConvertUsing<VerblijfplaatsVoorkomenConverter>();
    }
}

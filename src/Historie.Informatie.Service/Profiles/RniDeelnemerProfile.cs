using AutoMapper;
using Src = HaalCentraal.Generated.DataService;
using Trg = HaalCentraal.Generated.InformatieService;

namespace Historie.Informatie.Service.Profiles
{
    public class RniDeelnemerProfile : Profile
    {
        public RniDeelnemerProfile()
        {
            CreateMap<Src.RniDeelnemer, Trg.RniDeelnemer>();
        }
    }
}

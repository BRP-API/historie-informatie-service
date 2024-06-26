using AutoMapper;
using Src = HaalCentraal.Generated.DataService;
using Trg = HaalCentraal.Generated.InformatieService;

namespace Historie.Informatie.Service.Profiles
{
    public class WaardetabelProfile : Profile
    {
        public WaardetabelProfile()
        {
            CreateMap<Src.Waardetabel, Trg.Waardetabel>();
        }
    }
}

using AutoMapper;
using Historie.Data.Mock.Entities;
using Historie.Data.Mock.Generated;

namespace Historie.Data.Mock.Profiles;

public class GbaWaardetabelProfile : Profile
{
    public GbaWaardetabelProfile()
    {
        CreateMap<Waarde, Waardetabel>();
    }
}

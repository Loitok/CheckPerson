using AutoMapper;
using CheckPerson.DTOs.Person;

namespace CheckPerson.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<GetPersonWithLinkDto, GetPersonDto>().ForMember(x => x.Origin, 
                opt => opt.Ignore());
            CreateMap<GetPersonOriginDto, GetPersonOriginDto>();
        }
    }
}

using AutoMapper;
using MyApp.Application.Usrs;
using MyApp.Domain.Users;

namespace MyApp.Web
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserMapperProfile>();
        }


    }
}

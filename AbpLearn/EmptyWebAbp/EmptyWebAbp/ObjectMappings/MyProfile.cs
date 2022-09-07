using AutoMapper;
using EmptyWebAbp.IServices.Dtos;
using EmptyWebAbp.Models;

namespace EmptyWebAbp.ObjectMappings
{
    public class MyProfile : Profile
    {
        public MyProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}

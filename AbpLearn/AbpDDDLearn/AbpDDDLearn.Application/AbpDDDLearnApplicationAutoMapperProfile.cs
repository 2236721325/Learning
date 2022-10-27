using AbpDDDLearn.Application.Contracts.Dtos;
using AbpDDDLearn.Domain.Models;
using AutoMapper;

namespace AbpDDDLearn.Application
{
    public class AbpDDDLearnApplicationAutoMapperProfile : Profile
    {
        public AbpDDDLearnApplicationAutoMapperProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, UserDto>();
            
        }
    }
}
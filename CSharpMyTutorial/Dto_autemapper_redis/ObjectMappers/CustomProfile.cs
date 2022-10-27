using AutoMapper;
using Dto_autemapper_redis.Dtos;
using Dto_autemapper_redis.Models;

namespace Dto_autemapper_redis.ObjectMappers
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<User, UserDto>();

        }

    }
}

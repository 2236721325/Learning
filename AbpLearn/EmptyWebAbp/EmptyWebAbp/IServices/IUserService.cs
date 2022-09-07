using EmptyWebAbp.IServices.Dtos;
using EmptyWebAbp.Shared;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EmptyWebAbp.IServices
{

    public interface IUserService:IApplicationService
    {
         Task<ApiResult> Registe(CreateUserDto createUserDto);
         Task<ApiResult> Update(UpdateUserDto updateUserDto);
         Task<ApiResult> Login(UserLoginDto userLoginDto);
         Task<ApiResult<UserDto>> GetAsync(Guid id);
    }
}

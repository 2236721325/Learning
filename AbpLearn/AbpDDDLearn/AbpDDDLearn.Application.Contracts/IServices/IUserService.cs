using AbpDDDLearn.Application.Contracts.Dtos;
using AbpDDDLearn.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpDDDLearn.Application.Contracts.IServices
{
    public interface IUserService : IApplicationService
    {
        public Task<ApiResult> Registe(CreateUserDto createUserDto);
        public Task<ApiResult> Login(UserLoginDto userLoginDto);
        public Task<ApiResult> ChangePassword(UpdateUserDto updateUserDto);
        public Task<ApiResult<List<UserDto>>> GetAll();
    }
}

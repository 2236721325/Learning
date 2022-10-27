using AbpDDDLearn.Application.Contracts.Dtos;
using AbpDDDLearn.Application.Contracts.IServices;
using AbpDDDLearn.Domain.Models;
using AbpDDDLearn.Domain.Shared;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace AbpDDDLearn.Application.Services
{
    public class UserService : CrudAppService<User, UserDto, Guid, PagedResultDto<UserDto>, CreateUserDto, UpdateUserDto>, IUserService
    {

        //public UserService(IRepository<User, Guid> repository, IGuidGenerator guidGenerator)
        //{
        //    _Repository = repository;
        //    _GuidGenerator = guidGenerator;
        //}
        ///// <summary>
        ///// 更改密码
        ///// </summary>
        ///// <param name="updateUserDto"></param>
        ///// <returns></returns>
        //public async Task<ApiResult> ChangePassword(UpdateUserDto updateUserDto)
        //{
        //    var user=await _Repository.FindAsync(updateUserDto.Id);
        //    if (user == null) return new ApiResult()
        //    {
        //        Status = false,
        //        Message = "Id不存在！"
        //    };
        //    user.ChangePassword(updateUserDto.Password);
        //    await _Repository.UpdateAsync(user, true);
        //    return new ApiResult()
        //    {
        //        Status = true
        //    };
        //}

        //public async Task<ApiResult<List<UserDto>>> GetAll()
        //{
        //    return new ApiResult<List<UserDto>>()
        //    {
        //        Status = true,
        //        Result =ObjectMapper.Map<List<User>, List<UserDto>>(await _Repository.ToListAsync())
        //    };
        //}

        //public async Task<ApiResult> Login(UserLoginDto userLoginDto)
        //{
        //    var user = await _Repository.FindAsync(e => e.UserName == userLoginDto.UserName && e.Password == userLoginDto.Password);
        //    if (user == null)
        //    {
        //        return new ApiResult()
        //        {
        //            Status = false,
        //            Message = "账号密码错误"
        //        };
        //    }
        //    return new ApiResult()
        //    {
        //        Status = true
        //    };
        //}

        //public async Task<ApiResult> Registe(CreateUserDto createUserDto)
        //{
        //    var temp = await _Repository.FindAsync(e => e.UserName == createUserDto.UserName);
        //    if (temp != null)
        //    {
        //        return new ApiResult()
        //        {
        //            Status = false,
        //            Message = "该用户名已存在！"
        //        };
        //    }
        //    var user = ObjectMapper.Map<CreateUserDto, User>(createUserDto);
        //    user.CreateGuid(_GuidGenerator.Create());
        //    await _Repository.InsertAsync(user, true);
        //    return new ApiResult()
        //    {
        //        Status = true
        //    };
        //}
        public UserService(IRepository<User, Guid> repository) : base(repository)
        {

        }
    }
}

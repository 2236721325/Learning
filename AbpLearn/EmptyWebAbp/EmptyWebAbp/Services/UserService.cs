using EmptyWebAbp.Datas;
using EmptyWebAbp.IServices;
using EmptyWebAbp.IServices.Dtos;
using EmptyWebAbp.Models;
using EmptyWebAbp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Runtime.InteropServices;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Emailing;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.EventBus.Local;
using Volo.Abp.Guids;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Settings;

namespace EmptyWebAbp.Services
{

    public class UserService : ApplicationService, IUserService
    {
        private readonly IRepository<User, Guid> _Repository;
        private readonly IGuidGenerator _GuidGenerator;
        private readonly IDistributedCache<UserDto> _Cache;

        private readonly ILocalEventBus _LocalEventBus;
        private readonly IDistributedEventBus _DistributedEventBus;
        private readonly ISettingEncryptionService _SettingEncryptionService;
        private readonly ISettingDefinitionManager _SettingDefinitionManager;

        public  string GetString()
        {
            string str= "wmroysifgjymdafc";
            var setting = _SettingDefinitionManager.Get(EmailSettingNames.Smtp.Password);
            var psd = _SettingEncryptionService.Encrypt(setting, str);
            return psd;
        }

        public UserService(IRepository<User, Guid> repository, IGuidGenerator guidGenerator, IDistributedCache<UserDto> cache, ILocalEventBus localEventBus, IDistributedEventBus distributedEventBus, ISettingEncryptionService settingEncryptionService, ISettingDefinitionManager settingDefinitionManager)
        {
            Guid.NewGuid();
            _Repository = repository;
            _GuidGenerator = guidGenerator;
            _Cache = cache;
            _LocalEventBus = localEventBus;
            _DistributedEventBus = distributedEventBus;
            _SettingEncryptionService = settingEncryptionService;
            _SettingDefinitionManager = settingDefinitionManager;
        }
        public async Task<ApiResult<List<UserDto>>> GetAll()
        {
            var users=await _Repository.GetListAsync();
            var u = await _Repository.GetQueryableAsync();
            var dtos=ObjectMapper.Map<List<User>,List<UserDto>>(users);

            return await Task.FromResult(ApiResult.Ok(dtos));
        }

        public async Task<ApiResult<UserDto>> GetAsync(Guid id)
        {
            var userdto = await _Cache.GetOrAddAsync(
              id.ToString(), //缓存键
              async () => await GetUserDtoFromDatabaseAsync(id),
              () => new DistributedCacheEntryOptions
              {
                  AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
              });
            return ApiResult.Ok(userdto);

        }
        private async Task<UserDto> GetUserDtoFromDatabaseAsync(Guid id)
        {
            Console.WriteLine("从数据库中获取");
            return ObjectMapper.Map<User, UserDto>(await _Repository.GetAsync(id));
            
        }

        public async Task<ApiResult> Login(UserLoginDto userLoginDto)
        {
            var user = await _Repository.FindAsync(e => e.UserName == userLoginDto.UserName && e.Password == userLoginDto.Password);
            if (user == null)
            {
                return new ApiResult()
                {
                    Status = false,
                    Message = "账号密码错误"
                };
            }
            return new ApiResult()
            {
                Status = true
            };
        }

        public async Task<ApiResult> Registe(CreateUserDto createUserDto)
        {
            var temp = await _Repository.FindAsync(e => e.UserName == createUserDto.UserName);
            if (temp != null)
            {
                return new ApiResult()
                {
                    Status = false,
                    Message = "该用户名已存在！"
                };
            }
            var user = ObjectMapper.Map<CreateUserDto, User>(createUserDto);
            user.CreateGuid(_GuidGenerator.Create());
            await _Repository.InsertAsync(user, true);
            await _LocalEventBus.PublishAsync(new LoginSucceedEvent()
            {
                Name = user.Name
            });
            return new ApiResult()
            {
                Status = true
            };
        }

        public async Task<ApiResult> Update(UpdateUserDto updateUserDto)
        {
            var temp = await _Repository.FindAsync(updateUserDto.Id);
            if (temp == null)
            {
                return new ApiResult()
                {
                    Status = false,
                    Message = "Id错误"
                };
            }
            temp.ChangePassword(updateUserDto.Password);
            await _Repository.UpdateAsync(temp, true);
            return ApiResult.Ok("成功");

        }

        public async  Task<ApiResult<PagedResultDto<UserDto>>> GetPagedList(string? name,int skipCount,int maxResultCount)
        {
            var query =await _Repository.GetQueryableAsync();
            if (name != null)
            {
                query=query.Where(e => e.Name.Contains(name));
            }
            long total = query.LongCount();
            var result = query.OrderBy("Id").PageBy(skipCount, maxResultCount).ToList();
            return ApiResult.Ok(new PagedResultDto<UserDto>(total, ObjectMapper.Map<List<User>, List<UserDto>>(result)));
            
        }
    }
}

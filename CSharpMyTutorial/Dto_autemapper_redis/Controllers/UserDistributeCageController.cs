using AutoMapper;
using Dto_autemapper_redis.Commoms;
using Dto_autemapper_redis.Commoms.GuidGenerator;
using Dto_autemapper_redis.Datas;
using Dto_autemapper_redis.Dtos;
using Dto_autemapper_redis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dto_autemapper_redis.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserDistributeCageController : ControllerBase
    {
        private readonly IGuidGenerator _GuidGenerator;
        private readonly IMapper _Mapper;
        private readonly MyDbContext _MyDbContext;
        private readonly IDistributedCache _DistributedCache;
        private bool isFromDb = true;

        public UserDistributeCageController(MyDbContext myDbContext, IMapper mapper, IGuidGenerator guidGenerator, IDistributedCache distributedCache)
        {
            _MyDbContext = myDbContext;
            _Mapper = mapper;
            _GuidGenerator = guidGenerator;
            _DistributedCache = distributedCache;
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<UserDto>> Get(Guid id)
        {
            isFromDb = false;
            var dtoJson = await _DistributedCache.GetStringAsync(id.ToString());
            if (dtoJson != null)
            {
                Console.WriteLine("从redis缓存中获取！");
                var result=JsonSerializer.Deserialize<ApiResult<UserDto>>(dtoJson);
                return result;

            }
            var dto = await GetByDb(id);
            await _DistributedCache.SetStringAsync(id.ToString(), JsonSerializer.Serialize(dto), new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(20)
            });
            Console.WriteLine("从数据库中取！");
            return dto;
        }

        private async Task<ApiResult<UserDto>> GetByDb(Guid id)//从数据库获取数据。
        {
            var user = await _MyDbContext.Users.FindAsync(id);
            if (user == null) return ApiResult.OhNo<UserDto>("id不存在！");
            var dto = _Mapper.Map<User, UserDto>(user);
            isFromDb = true;
            return ApiResult.Ok(dto);
        }

        [HttpGet]
        public async Task<ApiResult<List<UserDto>>> GetAll()
        {
            var users = await _MyDbContext.Users.ToListAsync();
            var dtos = _Mapper.Map<List<User>, List<UserDto>>(users);
            return ApiResult.Ok(dtos);
        }
        [HttpPost]
        public async Task<ApiResult> Registe(UserRegisteDto userRegisteDto)
        {
            var u = await _MyDbContext.Users.Where(e => e.Account == userRegisteDto.Account).FirstOrDefaultAsync();
            if (u != null) return ApiResult.OhNo("账号已存在！");
            var user = new User(_GuidGenerator.Create(), userRegisteDto.Name, userRegisteDto.Account, MD5Helper.MD5Encrypt32(userRegisteDto.Password));
            await _MyDbContext.Users.AddAsync(user);
            await _MyDbContext.SaveChangesAsync();
            return ApiResult.Ok("注册成功");

        }
        [HttpPost]
        public async Task<ApiResult<UserDto>> Login(UserLoginDto userLoginDto)
        {
            var loginHash = MD5Helper.MD5Encrypt32(userLoginDto.Password);
            var user = await _MyDbContext.Users.Where(e => e.Account == userLoginDto.Account && e.PasswordHash == loginHash).FirstOrDefaultAsync();
            if (user == null) return ApiResult.OhNo<UserDto>("账号密码错误!");
            return ApiResult.Ok(_Mapper.Map<User, UserDto>(user));
        }




    }

}
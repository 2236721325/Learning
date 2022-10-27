using AutoMapper;
using Dto_autemapper_redis.Commoms;
using Dto_autemapper_redis.Commoms.GuidGenerator;
using Dto_autemapper_redis.Datas;
using Dto_autemapper_redis.Dtos;
using Dto_autemapper_redis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dto_autemapper_redis.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IGuidGenerator _GuidGenerator;
        private readonly IMapper _Mapper;
        private readonly MyDbContext _MyDbContext;

        public UserController(MyDbContext myDbContext, IMapper mapper, IGuidGenerator guidGenerator)
        {
            _MyDbContext = myDbContext;
            _Mapper = mapper;
            _GuidGenerator = guidGenerator;
        }

        [HttpGet("{id}")]
        [ResponseCache(Duration =10086)]//������Ӧ����
        public async Task<ApiResult<UserDto>> Get(Guid id)
        {
            var user= await _MyDbContext.Users.FindAsync(id);
            if (user == null) return ApiResult.OhNo<UserDto>("id�����ڣ�");
            var dto = _Mapper.Map<User, UserDto>(user);
            Console.WriteLine("�����ݿ��ȡ");
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
            var u =await _MyDbContext.Users.Where(e => e.Account == userRegisteDto.Account).FirstOrDefaultAsync();
            if (u !=null) return ApiResult.OhNo("�˺��Ѵ��ڣ�");
            var user = new User(_GuidGenerator.Create(), userRegisteDto.Name, userRegisteDto.Account, MD5Helper.MD5Encrypt32(userRegisteDto.Password));
            await _MyDbContext.Users.AddAsync(user);
            await _MyDbContext.SaveChangesAsync();
            return ApiResult.Ok("ע��ɹ�");

        }
        [HttpPost]
        public async Task<ApiResult<UserDto>> Login(UserLoginDto userLoginDto)
        {
            var loginHash = MD5Helper.MD5Encrypt32(userLoginDto.Password);
            var user = await _MyDbContext.Users.Where(e=>e.Account==userLoginDto.Account&&e.PasswordHash==loginHash).FirstOrDefaultAsync();
            if (user == null) return ApiResult.OhNo<UserDto>("�˺��������!");
            return ApiResult.Ok(_Mapper.Map<User, UserDto>(user));
        }




    }

}
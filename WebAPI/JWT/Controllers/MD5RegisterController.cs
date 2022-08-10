using FluentValidation;
using FluentValidation.Results;
using JWT.Common;
using JWT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MD5RegisterController : ControllerBase
    {
        private IValidator<UserInfo> _validator;
        MyDbContext db;
        public MD5RegisterController(IValidator<UserInfo> validator, MyDbContext db)
        {
            _validator = validator;
            this.db = db;
        }

        [HttpPost]
        public async Task<ActionResult> Register(string name, string username, string pwd)
        {
            UserInfo user = new UserInfo()
            {
                Name = name,
                UserName = username,
                TempPwd = pwd
            };
            ValidationResult result = await _validator.ValidateAsync(user);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }
            var oldWriter = await db.UserInfos.Where(c => c.UserName == username).FirstAsync();
            if (oldWriter != null) return BadRequest("账号已经存在");

            user.UserPwd = MD5Helper.MD5Encrypt32(user.TempPwd);
            await db.UserInfos.AddAsync(user);
            await db.SaveChangesAsync();
            return Ok("注册成功");
        }
    }
}
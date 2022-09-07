using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTLearn.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class JWTLoginController : ControllerBase
    {
        private readonly JWTSettings jwtSettings;

        public JWTLoginController(IOptions<JWTSettings> jwtSettings)
        {
            this.jwtSettings = jwtSettings.Value;
        }
        //仅仅为了模拟演示
        //实际使用最好对其进行封装
        [HttpPost]
        public ActionResult<string> Login(string userName, string userPwd="s")
        {
            if (userName != "wyh" || userPwd != "wyh")
            {
                return NotFound("用户名或密码错误");
            }
            //使用EFCORE 就在此创建用户

            List<Claim> claims = new List<Claim>()//不要放太多东西 数据的传输也是耗时的
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Name,"wyh"),
                new Claim(ClaimTypes.Role,"管理员"),
                new Claim(ClaimTypes.Role,"王耀华")
            };

            DateTime expirationTime = DateTime.Now.AddHours(jwtSettings.ExpirationHour);
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
            var jwtToken = new JwtSecurityToken(issuer:jwtSettings.Issuer,audience:jwtSettings.Audience,claims: claims, expires: expirationTime, signingCredentials: credentials);
            string jwt = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            //生成的字符串极其长 仅仅为了测试
            return Ok(jwt);
        }
    }

}
using IdentityModel;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Volo.Abp.Application.Services;

namespace AbpSomeModuleLearns.Services
{
    public class LoginService : ApplicationService
    {
        private readonly JWTSettings jwtSettings;

        public LoginService(IOptions<JWTSettings> jwtSettings)
        {
            this.jwtSettings = jwtSettings.Value;
        }

        public async Task<string> Login()
        {

            // 1 定义需要的Cliam信息
            List<Claim> claims = new List<Claim>()//不要放太多东西 数据的传输也是耗时的
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Name,"wyh"),
                new Claim(ClaimTypes.Role,"管理员"),
                new Claim(ClaimTypes.Role,"王耀华"),
            };

            DateTime expirationTime = DateTime.Now.AddHours(jwtSettings.ExpirationHour);
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
            var jwtToken = new JwtSecurityToken(issuer: jwtSettings.Issuer, audience: jwtSettings.Audience, claims: claims, expires: expirationTime, signingCredentials: credentials);
            string jwt = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return jwt;
        }
    }
}

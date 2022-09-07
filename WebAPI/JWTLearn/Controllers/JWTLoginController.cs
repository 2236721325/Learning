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
        //����Ϊ��ģ����ʾ
        //ʵ��ʹ����ö�����з�װ
        [HttpPost]
        public ActionResult<string> Login(string userName, string userPwd="s")
        {
            if (userName != "wyh" || userPwd != "wyh")
            {
                return NotFound("�û������������");
            }
            //ʹ��EFCORE ���ڴ˴����û�

            List<Claim> claims = new List<Claim>()//��Ҫ��̫�ණ�� ���ݵĴ���Ҳ�Ǻ�ʱ��
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Name,"wyh"),
                new Claim(ClaimTypes.Role,"����Ա"),
                new Claim(ClaimTypes.Role,"��ҫ��")
            };

            DateTime expirationTime = DateTime.Now.AddHours(jwtSettings.ExpirationHour);
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
            var jwtToken = new JwtSecurityToken(issuer:jwtSettings.Issuer,audience:jwtSettings.Audience,claims: claims, expires: expirationTime, signingCredentials: credentials);
            string jwt = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            //���ɵ��ַ������䳤 ����Ϊ�˲���
            return Ok(jwt);
        }
    }

}
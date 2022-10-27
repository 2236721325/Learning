using Abp从0搭建授权中心.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Abp从0搭建授权中心.Services
{
    public class LoginService : ApplicationService
    {
        private readonly IRepository<User, Guid> _Repository;
        private readonly IRepository<Role, Guid> _RoleRepository;
        private readonly IRepository<UserRole> _UserRoleRepository;
        private readonly JWTSettings jwtSettings;

        public LoginService(IRepository<User, Guid> repository, IRepository<Role, Guid> roleRepository, IRepository<UserRole> userRoleRepository, IOptions<JWTSettings> jwtSettings)
        {
            _Repository = repository;
            _RoleRepository = roleRepository;
            _UserRoleRepository = userRoleRepository;
            this.jwtSettings = jwtSettings.Value;
        }

        public  async Task<string> Login(string name)
        {
            var user=await _Repository.FindAsync(e => e.Name == name);
            var userrole = await _UserRoleRepository.FindAsync(e => e.UserId == user.Id);
            var role = await _RoleRepository.FindAsync(userrole.RoleId);


            List<Claim> claims = new List<Claim>()//不要放太多东西 数据的传输也是耗时的
            {
                new Claim("id",user.Id.ToString()),
                new Claim(ClaimTypes.Role,role.Name)
            };

            DateTime expirationTime = DateTime.Now.AddHours(jwtSettings.ExpirationHour);
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
            var jwtToken = new JwtSecurityToken(issuer: jwtSettings.Issuer, audience: jwtSettings.Audience, claims: claims, expires: expirationTime, signingCredentials: credentials);
            string jwt = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            //生成的字符串极其长 仅仅为了测试
            return jwt;

        }
    }
}

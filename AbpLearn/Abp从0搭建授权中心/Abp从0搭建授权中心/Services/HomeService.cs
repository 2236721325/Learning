using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Services;

namespace Abp从0搭建授权中心.Services
{
    [Authorize(Roles ="超级管理员")]
    public class HomeService:ApplicationService
    {
        public string SayHello()
        {
            return "Hello";
        }
    }
}

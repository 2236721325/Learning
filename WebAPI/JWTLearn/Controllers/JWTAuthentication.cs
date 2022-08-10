using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTLearn.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class JWTAuthentication : ControllerBase
    {

        
        [Authorize(Roles ="管理员")]//请求的时候需要带上JWT返回的Token// 用Postman做测试
        [HttpGet]
        public ActionResult ReturnIfLogin()
        {
            return Ok("已经登录");
        }
    }

}
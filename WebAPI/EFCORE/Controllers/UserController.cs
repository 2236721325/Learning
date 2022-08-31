using EFCORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCORE.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _MyDbContext;

        public UserController(MyDbContext myDbContext)
        {
            _MyDbContext = myDbContext;
        }
        [HttpPost]
        public ActionResult Add(string name)
        {
            _MyDbContext.Users.Add(new User()
            {
                Name = name
            });
            _MyDbContext.SaveChanges();
            return Ok();
        }
    }
}
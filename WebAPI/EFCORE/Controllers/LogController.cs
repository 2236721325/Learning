using EFCORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCORE.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LogController : ControllerBase
    {
        private readonly MyDbContext _MyDb;

        public LogController(MyDbContext myDb)
        {
            _MyDb = myDb;
        }
        //[HttpPost]
        //public ActionResult Add(int Userid, string name)
        //{
        //    var u = _MyDb.Users.Find(Userid);
        //    if (u == null) return NotFound();
        //    query.Add(new Log()
        //    {
        //        Name = name,
        //    });
        //    _MyDb.SaveChanges();
        //    return Ok();
        //}
        [HttpPost]
        public ActionResult FindById(int id)
        {
            return Ok(_MyDb.Logs.Where(e => e.UserId == id).ToList());
            
        }
    }
}
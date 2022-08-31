using Microsoft.AspNetCore.Mvc;

namespace WebAPI的一些约定操作返回类型.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<int>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public ActionResult Get(int id)
        {
            if (id == 0) return BadRequest("笑死我了");
            if (id == 1) return NotFound("你好");
            return Ok(new List<int>()
            {
                1,2,3,5
            });
        }
        [HttpGet]
        public ActionResult Get()
        {
            throw new Exception("我不好");
        }
    }
}
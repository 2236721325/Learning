using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace 使用Redis.Controllers
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
    }
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
      
        private readonly IDistributedCache _DistributedCache;

        public WeatherForecastController(IDistributedCache distributedCache)
        {
            _DistributedCache = distributedCache;
        }

        [HttpGet("{id}")]
        public async ActionResult Get(int id)
        {
            string result = await _DistributedCache.GetStringAsync($"Book{id}");
            if(result==null)
            {
                Console.WriteLine("数据库查");
                await _DistributedCache.SetStringAsync($"Book{id}",)
            }
          
        }
    }
}
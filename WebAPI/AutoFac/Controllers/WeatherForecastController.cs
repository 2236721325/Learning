using AutoFacDemo;
using AutofacModule;
using Microsoft.AspNetCore.Mvc;

namespace AutoFacDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
   
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ITestService _TestService;
        private readonly IService _Service;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ITestService testService, IService service)
        {
            _logger = logger;
            _TestService = testService;
            _Service = service;
        }
        [HttpPost]
        public void SayHello()
        {
            _TestService.SayHello();
            _Service.SayOk();
        }

      
    }
}
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace FirstService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DaprController : ControllerBase
    {
     

        [HttpGet("get1")]
        public async Task<ActionResult> Get1Async()
        {
            using var httpClient = DaprClient.CreateInvokeHttpClient(daprEndpoint:"http://localhost:8100");
            var result = await httpClient.GetAsync("http://second/WeatherForecast");
            var resultContent = string.Format("result is {0} {1}", result.StatusCode, await result.Content.ReadAsStringAsync());
            return Ok(resultContent);
        }

        // 通过DaprClient调用BackEnd
        [HttpGet("get2")]
        public async Task<ActionResult> Get2Async()
        {
            using var daprClient = new DaprClientBuilder().UseHttpEndpoint("http://localhost:8100").Build();
            var result = await daprClient.InvokeMethodAsync<IEnumerable<WeatherForecast>>(HttpMethod.Get, "second", "WeatherForecast");
            return Ok(result);
        }
    }
}
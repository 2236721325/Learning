using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;

namespace 使用Cap简化Rabbmitmq.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublishController : ControllerBase
    {

        [Route("~/send")]
        public IActionResult SendMessage([FromServices] ICapPublisher capBus)
        {
            capBus.Publish("test.show.time", DateTime.Now);
            return Ok();
        }



    }
    public class ConsumerController : ControllerBase
    {
        [NonAction]
        [CapSubscribe("test.show.time")]
        public void ReceiveMessage(DateTime time)
        {
            Console.WriteLine("message time is:" + time);
        }
    }
}
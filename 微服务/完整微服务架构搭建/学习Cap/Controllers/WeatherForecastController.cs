using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;

namespace 学习Cap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublishController : ControllerBase
    {
        [HttpPost]
        [Route("send")]
        public IActionResult SendMessage([FromServices] ICapPublisher capBus)
        {
            capBus.Publish("test.show.time", DateTime.Now);
            return Ok();
        }
        [NonAction]
        public IActionResult Press([FromServices] ICapPublisher capBus)
        {
            capBus.Publish("test.show.time", DateTime.Now);
            return Ok();
        }



    }
    //[ApiController]
    //[Route("[controller]")]
    public class ConsumerController
    {
        //[NonAction]
        [CapSubscribe("test.show.time")]
        public void ReceiveMessage(DateTime time)
        {
            Console.WriteLine("message time is:" + time);
        }
    }
}
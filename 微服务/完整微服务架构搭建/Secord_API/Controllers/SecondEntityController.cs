using API_Shared.IUnitOfWorks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Secord_API.Models;

namespace Secord_API.Controllers
{
    public class FirstEntityCreateMessage
    {
        public int FirstEntityId { get; set; }
        public string SecondEntityName { get; set; }
    }
    [ApiController]
    [Route("[controller]")]
    public class SecondEntityController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;

        public SecondEntityController(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("hello");
        }

        [NonAction]
        [CapSubscribe("First.FirstEntity.Create")]
        public async Task  CreateSecondEntity(FirstEntityCreateMessage message)
        {
            await _UnitOfWork.GetRepositoryByDI<SecondEntity>()
                .InsertAsync(new SecondEntity()
                {
                    FirstEntityId = message.FirstEntityId,
                    Name = message.SecondEntityName
                });
            await _UnitOfWork.SaveChangesAsync();
        }
    }
}
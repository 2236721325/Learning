using API_Shared;
using API_Shared.IUnitOfWorks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Secord_API.DbContexts;
using Secord_API.Models;

namespace First_API.Controllers
{
    public class FirstEntityCreateMessage
    {
        public int FirstEntityId { get; set; }
        public string SecondEntityName { get; set; }
    }
    [ApiController]
    [Route("api/[controller]")]
    public class FirstEntityController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;

        public FirstEntityController(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody]FirstEntity entity, [FromServices] ICapPublisher capPublisher)
        {
            //await _UnitOfWork.GetRepositoryByDI<FirstEntity>().InsertAsync(entity);
            //await _UnitOfWork.SaveChangesAsync();
            using (var trans = _UnitOfWork.GetDbContext<FirstDbContext>().Database.BeginTransaction(capPublisher,true))
            {
                await _UnitOfWork.GetRepositoryByDI<FirstEntity>()
             .InsertAsync(entity);
                await _UnitOfWork.SaveChangesAsync();
                await capPublisher.PublishAsync("First.FirstEntity.Create", new FirstEntityCreateMessage()
                {
                    FirstEntityId = entity.Id,
                    SecondEntityName = entity.SecondEntityName
                });
                return Ok();
                
            }
            
        }



    }
}
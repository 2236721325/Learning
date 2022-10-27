using FreesqlTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreesqlTest.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PoetController : ControllerBase
    {
        private readonly IFreeSql _FreeSql;

        public PoetController(IFreeSql freeSql)
        {
            _FreeSql = freeSql;
        }

        [HttpGet]
        public ActionResult<List<Poet>> Get()
        {
            return Ok(_FreeSql.Select<Poet>().ToList());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Poet>> Get(Guid id)
        {
            
            return Ok(_FreeSql.Select<Poet>().Where(e=>e.Id==id).Sign
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Poet value)
        {
            await value.InsertAsync();
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Poet value)
        {
           await value.UpdateAsync();
           return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
           await Poet.FindAsync(id)
                .Result.DeleteAsync();
            return Ok();
        }
    }
}

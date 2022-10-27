using AutoMapper;
using FreeSql.Internal.Model;
using FreeSqlDemo;
using FreeSqlDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FreeSqlDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        // GET api/Blog

        private readonly IFreeSql _FreeSql;
        private readonly IMapper _Mapper;

        public BlogController(IFreeSql freeSql, IMapper mapper)
        {
            _FreeSql = freeSql;
            _Mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogDto>> Get(int id)
        {
            var entity = await _FreeSql.Select<Blog>(id).FirstAsync();
            if (entity == null) return NotFound("Id不存在！");
            var dto = _Mapper.Map<Blog, BlogDto>(entity);
            return Ok(dto);

        }
        [HttpPost]
        public async Task<ActionResult<PagedDto<BlogDto>>> GetPagedList(PageSearchDto search)
        {

            var selects = _FreeSql.Select<Blog>().Count(out var totalCount)
               .Page(search.PageNumber, search.PageSize);
            if (search.FilterInfos!=null)
            {
                var dyfilter = JsonConvert.DeserializeObject <DynamicFilterInfo>(search.FilterInfos);
                selects = selects.WhereDynamicFilter(dyfilter);
            }


            var dtos =await selects.ToListAsync<BlogDto>();
            return Ok(new PagedDto<BlogDto>(dtos, totalCount));
        }

      

       

        [HttpPost]
        public async Task<IActionResult> Insert(BlogCreateDto create)
        {
            var entity = _Mapper.Map<BlogCreateDto, Blog>(create);
            var rows=await _FreeSql.Insert(entity).ExecuteAffrowsAsync();
            if (rows > 0) return Ok();
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Update(BlogUpdateDto update)

        { 
            var entity = _Mapper.Map<BlogUpdateDto, Blog>(update);
            var rows = await _FreeSql.Update<Blog>()
                .SetSource(entity)
                .ExecuteAffrowsAsync();
            if (rows > 0) return Ok("更新成功！");
            return NotFound("id不存在！");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rows=await _FreeSql.Delete<Blog>(new { BlogId = id }).ExecuteAffrowsAsync();
            if (rows > 0) return Ok("删除成功！");
            return NotFound("id不存在！");
        }
    }
}
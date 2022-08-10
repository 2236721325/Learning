using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace 使用过滤器实现缓存_内存缓存_.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MemoryCageDemoController : ControllerBase
    {
        IMemoryCache cage;

        public MemoryCageDemoController(IMemoryCache cage)
        {
            this.cage = cage;
            
        }

        [HttpPost]
        [TypeFilter(typeof(ResourceCageFilter))]//使用Filter的优势
                                                //当然实际使用的时候需要多考虑
                                                //需要设置缓存过期实现 
                                                //防止缓存雪崩
                                                //防止缓存穿透
                                                //对某些实时性的数据要及时更新
                                                //这种使用中间件的缓存策略用起来很爽
        public async Task<ActionResult> PostTest(string userName,int id)
        {
            return await Task.FromResult(Ok("hello"));
        }
        

      
    }
}
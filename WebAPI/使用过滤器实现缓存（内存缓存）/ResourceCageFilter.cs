using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace 使用过滤器实现缓存_内存缓存_
{
    public class ResourceCageFilter:IResourceFilter
    {
        IMemoryCache cage;

        public ResourceCageFilter(IMemoryCache cage)
        {
            this.cage = cage;
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var key = context.HttpContext.Request.QueryString.Value;
            cage.Set(key, context.Result);
            Console.WriteLine("没有从缓存中读取"); 
            
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var key = context.HttpContext.Request.QueryString.Value;
            if (key == null) throw new ArgumentNullException("缓存特性标注接口必须带有参数否则无意义");
            if (cage.TryGetValue(key,out object value))
            {
                Console.WriteLine("从缓存中读取");
                context.Result = value as IActionResult;
            }

        }


    }
}
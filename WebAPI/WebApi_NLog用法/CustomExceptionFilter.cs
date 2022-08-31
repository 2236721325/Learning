using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi_NLog用法
{
    public class CustomExceptionFilter:IExceptionFilter
    {
        private readonly IHostEnvironment _HostEnvironment;
        private readonly ILogger<CustomExceptionFilter> _Logger;

        public CustomExceptionFilter(IHostEnvironment hostEnvironment, ILogger<CustomExceptionFilter> logger)
        {
            _HostEnvironment = hostEnvironment;
            _Logger = logger;
        }

        void IExceptionFilter.OnException(ExceptionContext context)
        {
            _Logger.LogError(context.Exception, "服务器异常！");
            if (!_HostEnvironment.IsDevelopment())
            {
                return;
            }
           
           
         
        }
    }
}

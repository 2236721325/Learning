using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;

namespace WebAPI的一些约定操作返回类型
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment env;
        private readonly ILogger<HttpGlobalExceptionFilter> logger;

        public HttpGlobalExceptionFilter(IWebHostEnvironment env, ILogger<HttpGlobalExceptionFilter> logger)
        {
            this.env = env;
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            //如果需要日志；
            //logger.LogError(new EventId(context.Exception.HResult),
            //    context.Exception,
            //    context.Exception.Message);


            ProblemDetails problemDetails = new ProblemDetails
            {
                Detail = context.Exception.ToString(),
                Status = StatusCodes.Status500InternalServerError,
                Title = "服务器异常！",
            };
            context.Result= new ObjectResult(problemDetails)
            {
                StatusCode = problemDetails.Status
            };
            context.ExceptionHandled = true;
        }

       
    }
}

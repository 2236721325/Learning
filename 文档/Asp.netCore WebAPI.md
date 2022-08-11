# Asp.netCore WebAPI

## 筛选器

每种筛选器类型都在筛选器管道中的不同阶段执行：

- 授权筛选器：
  - 首先运行。
  - 确定用户是否获得请求授权。
  - 如果请求未获授权，可以让管道短路。
- [资源筛选器](https://docs.microsoft.com/zh-cn/aspnet/core/mvc/controllers/filters?view=aspnetcore-6.0#resource-filters)：
  - 授权后运行。
  - [OnResourceExecuting](https://docs.microsoft.com/zh-cn/dotnet/api/microsoft.aspnetcore.mvc.filters.iresourcefilter.onresourceexecuting) 在筛选器管道的其余阶段之前运行代码。 例如，`OnResourceExecuting` 在模型绑定之前运行代码。
  - [OnResourceExecuted](https://docs.microsoft.com/zh-cn/dotnet/api/microsoft.aspnetcore.mvc.filters.iresourcefilter.onresourceexecuted) 在管道的其余阶段完成之后运行代码。
- [操作筛选器](https://docs.microsoft.com/zh-cn/aspnet/core/mvc/controllers/filters?view=aspnetcore-6.0#action-filters)：
  - 在调用操作方法之前和之后立即运行。
  - 可以更改传递到操作中的参数。
  - 可以更改从操作返回的结果。
  - 不可在 Razor Pages 中使用。
- [异常筛选器](https://docs.microsoft.com/zh-cn/aspnet/core/mvc/controllers/filters?view=aspnetcore-6.0#exception-filters)在向响应正文写入任何内容之前，对未经处理的异常应用全局策略。
- [结果筛选器](https://docs.microsoft.com/zh-cn/aspnet/core/mvc/controllers/filters?view=aspnetcore-6.0#result-filters)：
  - 在执行操作结果之前和之后立即运行。
  - 仅当操作方法成功执行时才会运行。
  - 对于必须围绕视图或格式化程序的执行的逻辑，会很有用。

## DDD

DDD为指导微服务的原则

[.NET 微服务。 适用于容器化 .NET 应用程序的体系结构 | Microsoft Docs](https://docs.microsoft.com/zh-cn/dotnet/architecture/microservices/)

* 领域模型与事务脚本
* 通用语言,界限上下文
* 实体与值对象
* 聚合与聚合根
* 领域服务与应用服务
* 领域事件(MediatR)与集成事件(RabbitMQ)
* 充血模型与贫血模型 

## ABP vNext




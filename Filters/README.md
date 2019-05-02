Filters
=======
- Filters are code injected into request processing. There can be many categories of filters: authorization, caching, logging, exception, and more. The filters are executed after ActionInvocation, and after the middleware is executed on the ASP.NET Core pipeline.

- Filters allow you to perform certain actions before or after a certain stage of processing a request.

- Filters allow you to run code before or after specific stages in the
Request Processing Pipeline

- Filters are similar but NOT the same as Middleware.Middleware operate on the level of ASP.NET Core
Filters operate only on the level of MVC


### Filter Types
ASP.NET Core has the following filter types.Each is executed on a different stage of the Filter Pipeline.

| Filter | Description |
| ------ | ------ |
| Authorization Filter | Run first. Determine if the Client is authorized to access the Requested functionality. |
| Resource Filter | Run immediately after Authorization. Can run code before and after the rest of the pipeline |
| Action Filter | Run immediately before and after an individual Action Method is invoked |
| Exception Filter | Used to apply global policies for unhandled errors that occur |
| Result Filter | The filter is applied to the results of actions; it is executed both before and after receiving the result |

### Filter Pipeline

Together, all these types of filters form a filter pipeline (filter pipeline), which is embedded in the request processing process in MVC and which starts running after the MVC infrastructure has selected a controller method to process the request. At different stages of processing a request in this pipeline, the corresponding filter is called:

![alt text](https://andrewlock.net/content/images/2018/02/filters.png)

![alt text](https://dotnettricks.blob.core.windows.net/img/aspnetcore/aspnet-core-filters.jpg)

![alt text](https://media.ttmind.com/Media/tech/article_98_9-25-20182-00-52PM.png)

### Filter definition
Despite the fact that the filter conveyor is formed by five different types of filters, which are called at different stages and have their own strictly task, however, they all have common implementation points. So, all filters support two ways of implementation: synchronous and asynchronous. Depending on the method chosen, the filter class will implement one or another interface.

| Filter type | Synchronous interface | Asynchronous interface
| ------ | ------ | ------ |
| Authorization Filter | IAuthorizationFilter | IAsyncAuthorizationFilter |
| Resource Filter | IResourceFilter | IAsyncResourceFilter |
| Action Filter | IActionFilter | IAsyncActionFilter |
| Exception Filter | IExceptionFilter | IAsyncExceptionFilter |
| Result Filter | IResultFilter | IAsyncResultFilter |

All filters have the same scheme. The synchronous interface that filters implement is called I[Stage]Filter, where [Stage]is the request processing stage at which the filter is called. For example, for an authorization filter, the stage is conditionally called Authorization, for resource filters — Resoure, for action filters — Action, for result filters — Result, for exception filters — Exception.

Synchronous filters define two methods: On[Stage]Executingand On[Stage]Executed. The method On[Stage]Executingis called immediately before the Stage stage, and the method On[Stage]Executed immediately after the completion of the stage [Stage].

When implementing interfaces, it should be borne in mind that we can implement either only the synchronous or only the asynchronous version. If the class implements both options, then the system will call only the asynchronous interface method, and the implementation of the synchronous interface will be ignored.

## Synchronous Filter Example:
```c#
using System;
using Microsoft.AspNetCore.Mvc.Filters;

public class SimpleActionFilterAttribute : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        // code goes here
    }
 
     public void OnActionExecuted(ActionExecutedContext context)
     {
        // code goes here
     }
}
```

## Asynchronous Filter Example:
```c#
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

public class SimpleAsynActionFilterAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // code before
        await next();
        // code after
    }
}
```

## Applying Filters

- Controller method The attribute applies to the controller method
```c#
public class HomeController : Controller
{
    [SimpleActionFilter]
    public IActionResult Index()
    {
        return View();
    }
}
```
- The whole controller. The attribute applies to the controller class
```c#
[SimpleActionFilter]
public class HomeController : Controller
{
    // содержимое контроллера
}
```
- The global scope where the filter is applied to all methods of all controllers.
  To define a filter as global, we need to change the ConfigureServices()MVC service connection in the Startup class method
```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc(options =>
    {
        options.Filters.Add(typeof(SimpleActionFilter)); // подключение по типу
         
        // альтернативный вариант подключения
        //options.Filters.Add(new SimpleActionFilter()); // подключение по объекту
    });
}
```

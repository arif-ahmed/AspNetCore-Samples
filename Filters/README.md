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

### Plugins

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

## Installation

Use the package manager [nuget](https://www.nuget.org) to install Microsoft.AspNetCore.Diagnostics.

```bash
Install Microsoft.AspNetCore.Diagnostics
```

```c#
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    app.Run(async (context) =>
    {
        throw new Exception("Error Occurred while processing your request");
        await context.Response.WriteAsync("Request handled and response generated");
    });
}
```

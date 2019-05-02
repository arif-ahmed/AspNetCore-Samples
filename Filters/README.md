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

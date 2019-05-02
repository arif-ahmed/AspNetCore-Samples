Filters
=======
- Filters are code injected into request processing. There can be many categories of filters: authorization, caching, logging, exception, and more. The filters are executed after ActionInvocation, and after the middleware is executed on the ASP.NET Core pipeline.

- Filters allow you to perform certain actions before or after a certain stage of processing a request.

- Filters allow you to run code before or after specific stages in the
Request Processing Pipeline

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

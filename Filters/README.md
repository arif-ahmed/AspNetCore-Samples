Error Handling
==============
 - Developer Exception Page
 - Exception Handler
 - Status Code Pages
 - Exception Filters
 - Model Validation (ModelState)

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

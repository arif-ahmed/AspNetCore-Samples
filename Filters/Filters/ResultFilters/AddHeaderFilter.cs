using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Filters.ResultFilters
{
    public class AddHeaderFilterWithDi : IResultFilter
    {
        private ILogger _logger;
        public AddHeaderFilterWithDi
        (ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.
            CreateLogger<AddHeaderFilterWithDi>();
        }

        public void OnResultExecuting
        (ResultExecutingContext context)
        {
            var headerName = "OnResultExecuting";
            context.HttpContext.Response.
            Headers.Add(
                headerName, new string[]
                { "ResultExecutingSuccessfully" });
            _logger.LogInformation
            ($"Header added: {headerName}");
        }

        public void OnResultExecuted
        (ResultExecutedContext context)
        {
            // Can't add to headers here because the response has already begun.
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorHandling.Filters
{
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public string ViewName { get; set; } = "Error";
        public Type ExceptionType { get; set; } = null;
        public override void OnException(ExceptionContext context)
        {

            if(ExceptionType != null)
            {
                if (context.Exception.GetType() == this.ExceptionType)
                {
                    // do things accordingly
                }

                var result = new ViewResult { ViewName = this.ViewName };
                var modelMetadata = new EmptyModelMetadataProvider();
                result.ViewData = new ViewDataDictionary
                (modelMetadata, context.ModelState);
                result.ViewData.Add("HandleException", context.Exception);
                context.Result = result;
                context.ExceptionHandled = true;
            }
            else
            {
                var result = new ViewResult { ViewName = "Error" };
                var modelMetadata = new EmptyModelMetadataProvider();
                result.ViewData = new ViewDataDictionary
                (modelMetadata, context.ModelState);
                result.ViewData.Add("HandleException", context.Exception);
                context.Result = result;
                context.ExceptionHandled = true;
            }

        }
    }
}


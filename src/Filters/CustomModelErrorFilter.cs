using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;


public class CustomModelErrorFilter : ActionFilterAttribute
{
    public CustomModelErrorFilter()
    {
    }
   
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var logger = context.HttpContext.RequestServices.GetService<ILogger<CustomModelErrorFilter>>();

        logger.LogInformation($"[CustomModelErrorFilter] Model State {context.ModelState.IsValid}");
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                    .SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage)
                    .ToList();

            var responseObj = new
            {
                Message = "Bad Request",
                Errors = errors                    
            };

            context.Result = new JsonResult(responseObj)
            {
                StatusCode = 400
            };
        }
    }
}
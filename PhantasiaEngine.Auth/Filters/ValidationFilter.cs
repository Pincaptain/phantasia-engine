using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PhantasiaEngine.Auth.Responses;

namespace PhantasiaEngine.Auth.Filters
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(pair => pair.Value.Errors.Any())
                    .ToDictionary(pair => pair.Key, 
                        pair => pair.Value.Errors.Select(error => error.ErrorMessage))
                    .ToArray();

                var errorResponse = new ErrorResponse();

                foreach (var (field, fieldErrors) in errors)
                {
                    foreach (var error in fieldErrors)
                    {
                        var errorModel = new ErrorModel
                        {
                            Field = field,
                            Message = error
                        };
                        
                        errorResponse.Errors.Add(errorModel);
                    }
                }

                context.Result = new BadRequestObjectResult(errorResponse);
                
                return;
            }

            await next();
        }
    }
}
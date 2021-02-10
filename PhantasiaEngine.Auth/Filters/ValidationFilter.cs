using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PhantasiaEngine.Auth.Responses;

namespace PhantasiaEngine.Auth.Filters
{
    /// <summary>
    /// <c>ValidationFilter</c> middleware class is an <c>IAsyncActionFilter</c> that filers
    /// all the incoming requests based on their validation status.
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ValidationFilter : IAsyncActionFilter
    {
        /// <summary>
        /// Filters all the incoming requests and returns a BadRequest(400) if the model state is invalid
        /// and continues if the model state is valid.
        /// </summary>
        /// <param name="context">The current action executing context.</param>
        /// <param name="next">The delegate that indicates that the action of the filter completed.</param>
        /// <returns></returns>
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

                foreach (var (key, value) in errors)
                {
                    foreach (var error in value)
                    {
                        var errorModel = new ErrorModel
                        {
                            Field = key,
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
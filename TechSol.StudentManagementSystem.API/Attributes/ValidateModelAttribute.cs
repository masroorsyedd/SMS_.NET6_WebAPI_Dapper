using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TechSol.StudentManagementSystem.API.Models.Responses;

namespace TechSol.StudentManagementSystem.API.Attributes
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var message = string.Join(" | ", context.ModelState.Values
                                    .SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage));


                context.Result = new BadRequestObjectResult(new ErrorResponse(message));
            }
        }
    }
}

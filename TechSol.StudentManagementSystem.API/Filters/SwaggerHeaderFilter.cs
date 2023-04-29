using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TechSol.StudentManagementSystem.API.Filters
{
    public class SwaggerHeaderFilter : IOperationFilter
    {
       
        List<string> NoAuthHeaderController = new List<string>()
        {
            "Account","UserType"
        };
        void IOperationFilter.Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (NoAuthHeaderController.Any(x => x == context.MethodInfo.ReflectedType.Name.Replace("Controller", "")))
            {
                return;
            }

            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "accesstoken",
                In = ParameterLocation.Header,
                Required = false // set to false if this is optional
            });
        }
    }
}

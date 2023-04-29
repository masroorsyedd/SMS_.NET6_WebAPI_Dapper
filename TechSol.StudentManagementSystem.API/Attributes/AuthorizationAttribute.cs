using Microsoft.AspNetCore.Mvc;
using TechSol.StudentManagementSystem.API.Filters;

namespace TechSol.StudentManagementSystem.API.Attributes
{
    public class AuthorizationAttribute : TypeFilterAttribute
    {
        public AuthorizationAttribute() : base(typeof(AuthorizationFilter))
        {

        }

    }
}
    

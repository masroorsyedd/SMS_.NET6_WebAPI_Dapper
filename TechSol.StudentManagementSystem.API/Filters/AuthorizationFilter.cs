using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using TechSol.StudentManagementSystem.Utility.Security;

namespace TechSol.StudentManagementSystem.API.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        const string tokenKey = "accesstoken";
        private enum TokenAuthorization : int
        {
            Authorized = 0,
            InvalidToken = 1,
            MissingToken = 2,
            MissingAPIKey = 3,
            InvalidAPIKey = 4,
            UnAuthorized = 5,
            TokenExpire = 6
        }

        //protected IActionResult SendResponse(APIErrorResponse response)
        //{
        //    return new ObjectResult(response)
        //    {
        //        StatusCode = (int)response.Code
        //    };
        //}

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            switch (AuthorizeToken(context))
            {
                case TokenAuthorization.Authorized:
                    //DO NOTHING
                    break;
                case TokenAuthorization.InvalidToken:
                    throw new UnauthorizedAccessException("Invalid Token");
                    //break;
                //context.Result = SendResponse(new APIErrorResponse("Invalid Token", HttpStatusCode.Unauthorized)
                case TokenAuthorization.InvalidAPIKey:
                    //context.Result = SendResponse(new APIErrorResponse("Invalid API Key", HttpStatusCode.Unauthorized));
                    throw new UnauthorizedAccessException("Invalid API Key");
                    //break;
                case TokenAuthorization.MissingToken:
                    //context.Result = SendResponse(new APIErrorResponse("Missing Token", HttpStatusCode.Unauthorized));
                    throw new UnauthorizedAccessException("Missing Token");
                    //break;
                case TokenAuthorization.MissingAPIKey:
                    //context.Result = SendResponse(new APIErrorResponse("Missing API Key", HttpStatusCode.Unauthorized));
                    throw new UnauthorizedAccessException("Missing API Key");
                    //break;
                case TokenAuthorization.UnAuthorized:
                    //context.Result = SendResponse(new APIErrorResponse("Unauthorized", HttpStatusCode.Unauthorized));
                    throw new UnauthorizedAccessException("Unauthorized");
                    //break;
                case TokenAuthorization.TokenExpire:
                    //context.Result = SendResponse(new APIErrorResponse("Token has been expired", HttpStatusCode.Unauthorized));
                    throw new UnauthorizedAccessException("Token has been expired");
                    //break;
                default:
                    break;
            }
        }
        private TokenAuthorization AuthorizeToken(AuthorizationFilterContext actionContext)
        {
            if (!actionContext.HttpContext.Request.Headers.Any(x => x.Key == tokenKey))
            {
                return TokenAuthorization.MissingToken;
            }
            else
            {

                string token = actionContext.HttpContext.Request.Headers[tokenKey][0];
                List<Claim> claims = JWTBuilder.IsTokenValid(token);

                if (claims == null)
                {
                    if (JWTBuilder.IsTokenExpired(token))
                        return TokenAuthorization.TokenExpire;
                    else
                        return TokenAuthorization.InvalidToken;
                }
               
                else
                {
                        actionContext.HttpContext.Items.Add(new KeyValuePair<object, object>("USERID", claims.FirstOrDefault(x => x.Type == "USERID").Value));
                        actionContext.HttpContext.Items.Add(new KeyValuePair<object, object>("USERNAME", claims.FirstOrDefault(x => x.Type == "USERNAME").Value));
                        actionContext.HttpContext.Items.Add(new KeyValuePair<object, object>("USERTYPEID", claims.FirstOrDefault(x => x.Type == "USERTYPEID").Value));
                        actionContext.HttpContext.Items.Add(new KeyValuePair<object, object>("USEREMAIL", claims.FirstOrDefault(x => x.Type == "USEREMAIL").Value));
                        actionContext.HttpContext.Items.Add(new KeyValuePair<object, object>("USERPASSWORD", claims.FirstOrDefault(x => x.Type == "USERPASSWORD").Value));
                        actionContext.HttpContext.Items.Add(new KeyValuePair<object, object>("BUSINESSID", claims.FirstOrDefault(x => x.Type == "BUSINESSID").Value));
                        actionContext.HttpContext.Items.Add(new KeyValuePair<object, object>("BUSINESSUSERID", claims.FirstOrDefault(x => x.Type == "BUSINESSUSERID").Value));
                }
                String path = Convert.ToString(actionContext.HttpContext.Request.Path);
                int businessId = 0;
                if (path.Contains("/Businesses/"))
                {

                    var segments = path.Split('/');
                    if (segments[segments.Length - 1].Equals("Businesses"))
                    {

                        return TokenAuthorization.UnAuthorized;

                    }
                    for (int i = 0; i < segments.Length; i++)
                    {

                        if (segments[i].Equals("Businesses"))
                        {

                            businessId = Convert.ToInt32(segments[i + 1]);
                            break;

                        }

                    }

                    if (businessId == 0)
                    {

                        return TokenAuthorization.InvalidToken;

                    }
                    else
                    {

                        if (businessId != Convert.ToInt32(actionContext.HttpContext.Items["BUSINESSID"]))
                        {

                            return TokenAuthorization.UnAuthorized;

                        }

                    }

                }


                return TokenAuthorization.Authorized;
                
            }
        }
    }
}

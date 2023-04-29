using Newtonsoft.Json;

namespace TechSol.StudentManagementSystem.API.Models.Responses
{
    public class ErrorResponse
    {
        #region Fields & Properties

        private string message;
        [JsonProperty(PropertyName = "message")]
        public string Message 
        { 
            get { return message; } 
            set { message = value; } 
        }

        #endregion

        public ErrorResponse(string message)
        {
            this.message = message;
        }

    }
}

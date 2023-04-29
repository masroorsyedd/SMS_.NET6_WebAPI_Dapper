using Newtonsoft.Json;

namespace TechSol.StudentManagementSystem.API.Models.Requests
{
    public class StudentRequest
    {
		[JsonProperty("studentName")]
		public virtual string StudentName { get; set; }
		[JsonProperty("email")]
		public virtual string Email { get; set; }
		[JsonProperty("gender")]
		public virtual string Gender { get; set; }
	}
}

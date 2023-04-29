using Newtonsoft.Json;

namespace TechSol.StudentManagementSystem.API.Models.Responses
{
    public class StudentResponse
    {
		[JsonProperty("studentId")]
		public virtual int StudentId { get; set; }
		[JsonProperty("studentName")]
		public virtual string StudentName { get; set; }
		[JsonProperty("email")]
		public virtual string Email { get; set; }
		[JsonProperty("gender")]
		public virtual string Gender { get; set; }
		[JsonProperty("active")]
		public virtual bool? Active { get; set; }
		[JsonProperty("createdOn")]
		public virtual DateTime? CreatedOn { get; set; }
		[JsonProperty("createdBy")]
		public virtual string CreatedBy { get; set; }
		[JsonProperty("lastModifiedOn")]
		public virtual DateTime? LastModifiedOn { get; set; }
		[JsonProperty("lastModifiedBy")]
		public virtual string LastModifiedBy { get; set; }
	}
}

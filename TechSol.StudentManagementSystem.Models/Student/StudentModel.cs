using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechSol.StudentManagementSystem.Models.Student
{
	/// <summary>
	/// A class which represents the tbl_students table.
	/// </summary>
	[Table("students")]
	public class StudentModel
	{
		[Key]
		[Column("StudentId")]
		public virtual int StudentId { get; set; }
		[Column("StudentName")]
		public virtual string StudentName { get; set; }
		[Column("Email")]
		public virtual string Email { get; set; }
		[Column("Gender")]
		public virtual string Gender { get; set; }
		[Column("Active")]
		public virtual bool? Active { get; set; }
		[Column("CreatedOn")]
		public virtual DateTime? CreatedOn { get; set; }
		[Column("CreatedBy")]
		public virtual string CreatedBy { get; set; }
		[Column("LastModifiedOn")]
		public virtual DateTime? LastModifiedOn { get; set; }
		[Column("LastModifiedBy")]
		public virtual string LastModifiedBy { get; set; }
	}
}

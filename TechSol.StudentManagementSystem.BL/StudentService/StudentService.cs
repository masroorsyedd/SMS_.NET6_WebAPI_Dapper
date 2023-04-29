using TechSol.StudentManagementSystem.DAL.Student;
using TechSol.StudentManagementSystem.Models.Student;

namespace TechSol.StudentManagementSystem.BL.StudentService
{
    public class StudentService
    {
        //private readonly IStudentRepository studentRepository;
        //public StudentService(IStudentRepository studentRepository)
        //{
        //    studentRepository = studentRepository;
        //}

        StudentRepository studentRepository = new StudentRepository();

        public Task<IEnumerable<StudentModel>> GetAllStudents()
        {
            return studentRepository.GetList<StudentModel>();
        }

        public StudentModel GetStudentById(int id)
        {
            return studentRepository.Get<StudentModel>(id).Result;
        }

        public int AddStudent(StudentModel student)
        {
            student.CreatedBy = "Admin";
            student.CreatedOn = DateTime.UtcNow;
            student.Active = true;
            return studentRepository.Insert(student).Result;
        }
        
        public int UpdateStudent(StudentModel student)
        {
            student.LastModifiedBy = "Masroor";
            student.LastModifiedOn = DateTime.UtcNow;
            return studentRepository.Update(student).Result;
        }

        public int DeleteStudent(int id)
        {
            return studentRepository.Delete(id).Result;
        }
    }
}

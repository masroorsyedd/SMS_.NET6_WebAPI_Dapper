using Mapster;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechSol.StudentManagementSystem.API.Models.Requests;
using TechSol.StudentManagementSystem.API.Models.Responses;
using TechSol.StudentManagementSystem.BL.StudentService;
using TechSol.StudentManagementSystem.Models.Student;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechSol.StudentManagementSystem.API.Controllers
{
    [SwaggerResponse(500,"Internal Server Error", Type = typeof(ErrorResponse))]
    [SwaggerResponse(401,"Unauthorized", Type = typeof(ErrorResponse))]
    [SwaggerResponse(400,"Bad Request", Type = typeof(ErrorResponse))]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/<StudentController>
        [Route("Students")]
        [HttpGet]
        [SwaggerResponse(200, "Success", Type = typeof(IEnumerable<StudentResponse>))]
        public IActionResult Get()
        {
            StudentService studentService = new StudentService();
            IEnumerable<StudentModel> studentModels = studentService.GetAllStudents().Result;

            IEnumerable<StudentResponse> studentResponses = studentModels.Adapt<IEnumerable<StudentResponse>>();

            return Ok(studentResponses);

        }

        // GET api/<StudentController>/5
        [Route("Students/{id}")]
        [HttpGet]
        [SwaggerResponse(200, "Success", Type = typeof(StudentResponse))]
        public IActionResult Get(int id)
        {
            //Create Service object
            StudentService studentService = new StudentService();

            //retrive data from DB by using ID given in request
            StudentModel studentModel = studentService.GetStudentById(id);

            //is tarha agar mein mapping krta hun tou source object (studentModel) mein jo bhi data hoga woh sara ka sara map hojaega destination object (StudentResponse) mein, or agar kch fields mein data nahi ara hoga source object se tou phr woh destination object ki field mein NULL fill krdega
            StudentResponse studentResponse = studentModel.Adapt<StudentResponse>();
            return Ok(studentResponse);
        }

        // POST api/<StudentController>
        [Route("Students")]
        [HttpPost]
        [SwaggerResponse(200, "Success", Type = typeof(StudentResponse))]
        public IActionResult Post(StudentRequest studentRequest)
        {
            //Map the request model that user filled with DB model
            StudentModel studentModel = studentRequest.Adapt<StudentModel>();

            //give the DB Model after filling with request data to Service to save it into DB
            StudentService studentService = new StudentService();
            int studentId = studentService.AddStudent(studentModel);

            //the id returned by DB, we use it to receive the complete record
            studentModel = studentService.GetStudentById(studentId);

            //Map the DB model with the response model and return it
            StudentResponse studentResponse = studentModel.Adapt<StudentResponse>();
            return Ok(studentResponse);
        }

        // PUT api/<StudentController>/5
        [Route("Students/{id}")]
        [HttpPut]
        [SwaggerResponse(200, "Success", Type = typeof(StudentResponse))]
        public IActionResult Put(int id, StudentRequest studentRequest)
        {
            //get data from DB by given the ID that comes in request
            StudentService studentService = new StudentService();
            StudentModel studentModel = studentService.GetStudentById(id);

            //jo data request mein ara hai woh map hojaega destination object mein or baqi jo fields hongi woh wesi he rhengi unme jo data hai wohi rhega
            studentModel = studentRequest.Adapt(studentModel);

            //give that model to DB for update, it will return 0 or 1 as updateStatus
            int isUpdated = studentService.UpdateStudent(studentModel);

            if(isUpdated ==1)
            {
                StudentResponse studentResponse = studentModel.Adapt<StudentResponse>();
                return Ok(studentResponse);
            }
            else
            {
                return BadRequest(new ErrorResponse("Something went wrong"));
            }
            
        }

        // DELETE api/<StudentController>/5
        [Route("Students/{id}")]
        [HttpDelete]
        [SwaggerResponse(200, "Success", Type = typeof(StudentResponse))]
        public IActionResult Delete(int id)
        {
            //gives the id that comes in request to Service for delete operation 
            StudentService studentService = new StudentService();

            //if delete successfully, it will return 1 otherwise 0
            int isDeleted = studentService.DeleteStudent(id);
            if(isDeleted ==1)
            {
                return Ok("Successfully Deleted");
            }
            else
            {
                return BadRequest(new ErrorResponse("Something went wrong"));
            }
        }
    }
}

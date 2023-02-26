using EnrollmentSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TicketingAPI.Dapper;

namespace EnrollmentSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IBaseAccessLayer _baseAccessLayer;

        public StudentController(IBaseAccessLayer baseAccessLayer)
        {
            _baseAccessLayer = baseAccessLayer;
        }
               
        [AllowAnonymous]
        [HttpGet("GetStudent")]
        public async Task<IEnumerable<Student>> GetStudent()
        {

            string query = $@"SELECT * FROM Student;";

            var result = await _baseAccessLayer.QueryListAsync<Student>(query, null, CommandType.Text);

            return result;
        }
               
        [AllowAnonymous]
        [HttpPost("Student")]
        public async Task<Student> SaveStudent([FromBody] Student student)
        {
            var query = _baseAccessLayer.GenerateInsertQuery<Student>("Student", student, "Id");
            var result = await _baseAccessLayer.ExecuteNonQueryAsync(query, student, commandType: CommandType.Text);

            return student;
        }

        [AllowAnonymous]
        [HttpGet("Student/{id}")]
        public async Task<Student> GetStudent(int id)
        {
            string query = $@"SELECT * FROM Student WHERE Id=@Id;";
            var result = await _baseAccessLayer.QuerySingleOrDefaultAsync<Student>(query, new { Id = id }, commandType: CommandType.Text);

            return result;
       
        }
    }
}




/*CRUD                                                        HTTP VERBS
 * CREATE - a new record                                    - POST
 * READ   - retrieve a single/list of record(s)             - GET
 * UPDATE - modify an existing record                       - PUT / PATCH
 * DELETE - remove an existing record                       - DELETE
*/
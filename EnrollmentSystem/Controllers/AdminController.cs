using EnrollmentSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TicketingAPI.Dapper;

namespace EnrollmentSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IBaseAccessLayer _baseAccessLayer;

        public AdminController(IBaseAccessLayer baseAccessLayer)
        {
            _baseAccessLayer = baseAccessLayer;
        }

        [AllowAnonymous]
        [HttpGet("GetUsers")]
        public async Task<IEnumerable<Users>> GetUsers()
        {

            string query = $@"SELECT * FROM [users];";

            var result = await _baseAccessLayer.QueryListAsync<Users>(query, null, CommandType.Text);

            return result;
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
        [HttpGet("GetCourse")]
        public async Task<IEnumerable<Course>> GetCourse()
        {

            string query = $@"SELECT * FROM Course;";

            var result = await _baseAccessLayer.QueryListAsync<Course>(query, null, CommandType.Text);

            return result;
        }


        [AllowAnonymous]
        [HttpPost("Users")]
        public async Task<Users> SaveUser([FromBody] Users user)
        {
            var query = _baseAccessLayer.GenerateInsertQuery<Users>("user", user, "Id");
            var result = await _baseAccessLayer.ExecuteNonQueryAsync(query, user, commandType: CommandType.Text);

            return user;
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
        [HttpPost("Course")]
        public async Task<Course> SaveCourse([FromBody] Course course)
        {
            var query = _baseAccessLayer.GenerateInsertQuery<Course>("Course", course, "Id");
            var result = await _baseAccessLayer.ExecuteNonQueryAsync(query, course, commandType: CommandType.Text);

            return course;
        }

        [AllowAnonymous]
        [HttpGet("User/{id}")]
        public async Task<Users> GetUser(int id)
        {
            string query = $@"SELECT * FROM [user] WHERE Id=@Id;";
            var result = await _baseAccessLayer.QuerySingleOrDefaultAsync<Users>(query, new { Id = id }, commandType: CommandType.Text);

            return result;

        }
        [AllowAnonymous]
        [HttpGet("Student/{id}")]
        public async Task<Student> GetStudent(int id)
        {
            string query = $@"SELECT * FROM Student WHERE Id=@Id;";
            var result = await _baseAccessLayer.QuerySingleOrDefaultAsync<Student>(query, new { Id = id }, commandType: CommandType.Text);

            return result;
        }
        [AllowAnonymous]
        [HttpGet("Course/{id}")]
        public async Task<Course> GetCourse(int id)
            {
                string query = $@"SELECT * FROM Course WHERE Id=@Id;";
                var result = await _baseAccessLayer.QuerySingleOrDefaultAsync<Course>(query, new { Id = id }, commandType: CommandType.Text);

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
using EnrollmentSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TicketingAPI.Dapper;

namespace EnrollmentSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly IBaseAccessLayer _baseAccessLayer;

        public CourseController(IBaseAccessLayer baseAccessLayer)
        {
            _baseAccessLayer = baseAccessLayer;
        }

        [AllowAnonymous]
        [HttpGet("GetCourses")]
        public async Task<IEnumerable<Course>> GetCourses()
        {

            string query = $@"SELECT * FROM [Course];";

            var result = await _baseAccessLayer.QueryListAsync<Course>(query, null, CommandType.Text);

            return result;
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
        [HttpGet("Course/{id}")]
        public async Task<Course> GetCourse(int id)
        {
            string query = $@"SELECT * FROM [Course] WHERE Id=@Id;";
            var result = await _baseAccessLayer.QuerySingleOrDefaultAsync<Course>(query, new { Id = id }, commandType: CommandType.Text);

            return result;
        }

        [AllowAnonymous]
        [HttpPut("UpdateCourse")]
        public async Task<Course> UpdateCourse([FromBody] Course course)
        {
            var query = _baseAccessLayer.GenerateUpdateQueryById<Course>("Course", course, "Id");
            var result = await _baseAccessLayer.ExecuteNonQueryAsync(query, course, commandType: CommandType.Text);

            return course;
        }

        [AllowAnonymous]
        [HttpDelete("DeleteCourse/{id}")]
        public async Task<bool> DeleteCourse(int id)
        {
            var query = _baseAccessLayer.GenerateDeleteQueryBySingleParameter("Course", "Id");
            var result = await _baseAccessLayer.ExecuteNonQueryAsync(query, new { Id = id }, commandType: CommandType.Text);
            return result > 0;
        }

    }
}

﻿using EnrollmentSystem.Models;
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
        [HttpGet("GetCourse")]
        public async Task<IEnumerable<Course>> GetCourse()
        {

            string query = $@"SELECT * FROM Course;";

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
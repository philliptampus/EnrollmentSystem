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
        [HttpPost("Users")]
        public async Task<Users> SaveUser([FromBody] Users user)
        {
            var query = _baseAccessLayer.GenerateInsertQuery<Users>("user", user, "Id");
            var result = await _baseAccessLayer.ExecuteNonQueryAsync(query, user, commandType: CommandType.Text);

            return user;
        }
                
        [AllowAnonymous]
        [HttpGet("User/{id}")]
        public async Task<Users> GetUser(int id)
        {
            string query = $@"SELECT * FROM [user] WHERE Id=@Id;";
            var result = await _baseAccessLayer.QuerySingleOrDefaultAsync<Users>(query, new { Id = id }, commandType: CommandType.Text);

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
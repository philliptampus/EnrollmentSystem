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
        public async Task<IEnumerable<User>> GetUsers()
        {

            string query = $@"SELECT * FROM [user];";

            var result = await _baseAccessLayer.QueryListAsync<User>(query, null, CommandType.Text);

            return result;
        }


        [AllowAnonymous]
        [HttpPost("User")]
        public async Task<User> SaveUser([FromBody] User user)
        {
            var query = _baseAccessLayer.GenerateInsertQuery<User>("user", user, "Id");
            var result = await _baseAccessLayer.ExecuteNonQueryAsync(query, user, commandType: CommandType.Text);

            return user;
        }

        [AllowAnonymous]
        [HttpGet("User/{id}")]
        public async Task<User> GetUser(int id)
        {
            string query = $@"SELECT * FROM [user] WHERE Id=@Id;";
            var result = await _baseAccessLayer.QuerySingleOrDefaultAsync<User>(query, new { Id = id }, commandType: CommandType.Text);

            return result;
        }

        [AllowAnonymous]
        [HttpPut("UpdateUser")]
        public async Task<User> UpdateUser([FromBody] User user)
        {
            var query = _baseAccessLayer.GenerateUpdateQueryById<User>("user", user, "Id");
            var result = await _baseAccessLayer.ExecuteNonQueryAsync(query, user, commandType: CommandType.Text);

            return user;
        }


    }
}

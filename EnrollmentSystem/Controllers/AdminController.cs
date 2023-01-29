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
        [HttpGet(Name = "GetUsers")]
        public async Task<IEnumerable<User>> GetUsers()
        {

            string query = $@"SELECT * FROM [user];";

            var result = await _baseAccessLayer.QueryListAsync<User>(query, null, CommandType.Text);

            return result;
        }
    }
}

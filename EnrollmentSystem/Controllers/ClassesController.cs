using EnrollmentSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TicketingAPI.Dapper;

namespace EnrollmentSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassesController : ControllerBase
    {
        private readonly IBaseAccessLayer _baseAccessLayer;

        public ClassesController(IBaseAccessLayer baseAccessLayer)
        {
            _baseAccessLayer = baseAccessLayer;
        }

        [AllowAnonymous]
        [HttpGet("GetClasses")]
        public async Task<IEnumerable<Classes>> GetClasses()
        {

            string query = $@"SELECT * FROM [Classes];";

            var result = await _baseAccessLayer.QueryListAsync<Classes>(query, null, CommandType.Text);

            return result;
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace EnrollmentSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();


            // IF statement
            var name = "Rogel";

            if (name == "Rogel")
            {
                // retrieve data

                return "Student";
            }
            else (name == "Phillip") {
                return "Trainer";
            }

            var studentNames = new string[] { "Rogel", "Phillip", "Rosselyn" };

            // Loop statement
            foreach (var student in studentNames) 
            {
                // get student details for each student
                
            }

            switch (name)
            {
                case "Rogel":
                    {

                    }
                case "Phillip":
                    {

                    }
                default:
                    break;
            }




        }
    }
}
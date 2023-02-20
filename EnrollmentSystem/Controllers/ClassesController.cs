using Microsoft.AspNetCore.Mvc;

namespace EnrollmentSystem.Controllers
{
    public class ClassesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

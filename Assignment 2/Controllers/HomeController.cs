using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }
    }
}

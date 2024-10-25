using Microsoft.AspNetCore.Mvc;

namespace Validation.Controllers
{
    [Route("Error")]
    public class ErrorController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            int statusCode = HttpContext.Response.StatusCode;

            if (statusCode == 404)
            {
                return View("NotFound"); 
            }
            else if (statusCode == 500)
            {
                return View("InternalServerError");
            }
            else
            {
                return View(statusCode);
            }
        }
    }
}
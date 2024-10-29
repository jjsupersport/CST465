using Microsoft.AspNetCore.Mvc;
using MyProject.Models;

namespace MyProject.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        [HttpGet("ContactHTML")]
        public IActionResult ContactHTML()
        {
            ViewBag.Title = "Contact - HTML";
            return View();
        }

        [HttpGet("ContactTagHelper")]
        public IActionResult ContactTagHelper()
        {
            ViewBag.Title = "Contact - Tag Helper";
            return View();
        }

        [HttpPost("Contact")]
        public IActionResult Contact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("ContactResult", model);
            }
            return View("ContactTagHelper", model); // Reload form if validation fails
        }

        [HttpGet("ContactResult")]
        public IActionResult ContactResult(ContactModel model)
        {
            ViewBag.Title = "Contact - Result";
            return View(model);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class AdminController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Admin";
        return View();
    }
}

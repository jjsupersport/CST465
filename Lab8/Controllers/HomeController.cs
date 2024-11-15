using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab8.Models;
using Lab8.Repositories;
using Lab8.DataObjects;
using Microsoft.AspNetCore.OutputCaching;

namespace Lab8.Controllers;
[Route("")]
[Route("Home")]
public class HomeController : Controller
{
    private readonly IImageRepository _ImageRepo;

    public HomeController(IImageRepository imageRepo)
    {
        _ImageRepo = imageRepo;
    }

    [HttpGet]
    public IActionResult AddImage()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddImage(ImageModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        using var memoryStream = new MemoryStream();
        await model.File.CopyToAsync(memoryStream);

        var image = new ImageObject
        {
            FileName = model.File.Name,
            Description = model.Description,
            FileData = memoryStream.ToArray()
        };

        //might need to await
        _ImageRepo.SaveImage(image);

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 1800)]
    [HttpGet("Image/{id}")]
    public async Task<IActionResult> GetImage(int id)
    {
        //return image file by id
        var image = _ImageRepo.GetImageData(id);
        if (image == null) return NotFound();

        return File(image, "image/jpeg");
    }

    [Route("")]
    [HttpGet("Index")]
    [OutputCache(Duration = 1800)]
    public IActionResult Index()
    {
        var images = _ImageRepo.GetImages();
        return View(images);
    }
    
    
}

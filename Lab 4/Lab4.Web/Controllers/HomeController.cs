using Lab4.Objects;
using System.Linq;
using System;
using System.Collections.Generic;
public class HomeController : Controller
{

    public IActionResult Index() 

    {

         return View(); 

    }

    public IActionResult Laborers()
    {
        ChoreWorkforce myWorkforce = new ChoreWorkforce();
        myWorkforce.Laborers.Add(new ChoreLaborer() { Name = "Bob", Age = 7, Difficulty = 5 });
        myWorkforce.Laborers.Add(new ChoreLaborer() { Name = "Alex", Age = 10, Difficulty = 4 });
        myWorkforce.Laborers.Add(new ChoreLaborer() { Name = "Calvin", Age = 12, Difficulty = 6 });
        myWorkforce.Laborers.Add(new ChoreLaborer() { Name = "Dee", Age = 9, Difficulty = 3 });
        myWorkforce.AddRandomLaborers(30);
        var filteredlaborers = myWorkforce.Laborers
        .Where(laborer => (laborer?.Age ?? -1) >= 3 && (laborer?.Age ?? -1) <= 10 && (laborer?.Difficulty ?? -1) <= 7)
        .OrderBy(laborer => laborer?.Name ?? "")
        .ToList();

        var filteredworkforce = new ChoreWorkforce();
        foreach(var laborer in filteredlaborers)
        {
            filteredworkforce.Laborers.Add(laborer);
        }

        return View(filteredworkforce);
    }

}
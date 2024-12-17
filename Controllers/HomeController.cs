using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TempData_MVC.Models;

namespace TempData_MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        //TempData : Dictionary tipinde bir yapıdır!!

        // TempDatayı, ViewData ve ViewBag'dan ayıran en önemli özellik, redirection ile veri taşıyabilme özelliğidir!!
        TempData["Message"]="Ben tempdata içerisinde taşınan bir mesajım!!";
       
        // 
        return RedirectToAction("Privacy");
    }

    public IActionResult Privacy()
    {
        string message = TempData["Message"].ToString();
        return RedirectToAction("Help");
    }
    public IActionResult Help(){

        string message = TempData["Message"].ToString();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

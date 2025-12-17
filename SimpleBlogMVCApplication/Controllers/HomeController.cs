using Microsoft.AspNetCore.Mvc;

namespace SimpleBlogMVCApplication.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return RedirectToAction("Index", "Post"); 
    }
}
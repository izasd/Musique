using Musique.Data;
using Microsoft.AspNetCore.Mvc;

namespace Musique.Controllers;

public class HomeController : Controller
{
    private readonly DataContext _db;

    public HomeController(DataContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }
}
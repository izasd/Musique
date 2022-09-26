using Musique.Data;
using Musique.Models;
using Microsoft.AspNetCore.Mvc;

namespace Musique.Controllers;

public class OuvinteController : Controller
{
    private readonly DataContext _db;

    public OuvinteController(DataContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var ouvintes = _db.Ouvintes.ToList();
        return View(ouvintes);
    }
}
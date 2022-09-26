using Musique.Data;
using Musique.Models;
using Microsoft.AspNetCore.Mvc;

namespace Musique.Controllers;

public class ModeradorController : Controller
{
    private readonly DataContext _db;

    public ModeradorController(DataContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var moderadores = _db.Moderadores.ToList();
        return View(moderadores);
    }
}
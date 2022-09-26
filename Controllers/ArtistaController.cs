using Musique.Data;
using Musique.Models;
using Microsoft.AspNetCore.Mvc;

namespace Musique.Controllers;

public class ArtistaController : Controller
{
    private readonly DataContext _db;

    public ArtistaController(DataContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var artistas = _db.Artistas.ToList();
        return View(artistas);
    }
}
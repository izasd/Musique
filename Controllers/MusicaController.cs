using Musique.Data;
using Musique.Models;
using Microsoft.AspNetCore.Mvc;

namespace Musique.Controllers;

public class MusicaController : Controller
{
    private readonly DataContext _db;

    public MusicaController(DataContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var musicas = _db.Musicas.ToList();
        return View(musicas);
    }
}
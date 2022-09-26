using Musique.Data;
using Musique.Models;
using Microsoft.AspNetCore.Mvc;

namespace Musique.Controllers;

public class GeneroController : Controller
{
    private readonly DataContext _db;

    public GeneroController(DataContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var generos = _db.Generos.ToList();
        return View(generos);
    }
}
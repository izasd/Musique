using Musique.Data;
using Musique.Models;
using Microsoft.AspNetCore.Mvc;

namespace Musique.Controllers;

public class AlbumController : Controller
{
    private readonly DataContext _db;

    public AlbumController(DataContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var albuns = _db.Albuns.ToList();
        return View(albuns);
    }
}
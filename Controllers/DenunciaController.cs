using Musique.Data;
using Musique.Models;
using Microsoft.AspNetCore.Mvc;

namespace Musique.Controllers;

public class DenunciaController : Controller
{
    private readonly DataContext _db;

    public DenunciaController(DataContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var denuncias = _db.Denuncias.ToList();
        return View(denuncias);
    }
}
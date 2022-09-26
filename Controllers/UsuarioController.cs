using Musique.Data;
using Musique.Models;
using Microsoft.AspNetCore.Mvc;

namespace Musique.Controllers;

public class UsuarioController : Controller
{
    private readonly DataContext _db;

    public UsuarioController(DataContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var usuarios = _db.Usuarios.ToList();
        return View(usuarios);
    }
}
using Musique.Data;
using Musique.Models;
using Microsoft.AspNetCore.Mvc;

namespace Musique.Controllers;

public class SugestaoController : Controller
{
    private readonly DataContext _db;

    public SugestaoController(DataContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var sugestoes = _db.Sugestoes.ToList();
        return View(sugestoes);
    }
}
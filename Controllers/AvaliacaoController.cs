using Musique.Data;
using Musique.Models;
using Microsoft.AspNetCore.Mvc;

namespace Musique.Controllers;

public class AvaliacaoController : Controller
{
    private readonly DataContext _db;

    public AvaliacaoController(DataContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var avaliacoes = _db.Avaliacoes.ToList();
        return View(avaliacoes);
    }
}
using Musique.Data;
using Musique.Models;
using Microsoft.AspNetCore.Mvc;

namespace Musique.Controllers;

public class GravacaoController : Controller
{
    private readonly DataContext _db;

    public GravacaoController(DataContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var gravacoes = _db.Gravacoes.ToList();
        return View(gravacoes);
    }
}
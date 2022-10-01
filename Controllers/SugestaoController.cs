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

    public IActionResult Create()
    {
        var sugestao = new Sugestao();
        sugestao.IdOuvinte = 1;
        sugestao.Estado = EnumEstadoModeracao.Pendente;
        return View(sugestao);
    }
    [HttpPost]
    public IActionResult Create(Sugestao sugestao)
    {
        if(!ModelState.IsValid) return View(sugestao);
        _db.Sugestoes.Add(sugestao);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Avaliar(int id)
    {
        var sugestao = _db.Sugestoes.Find(id);
        if(sugestao is null)
            return RedirectToAction("Index");
        return View(sugestao);
    }
    [HttpPost]
    public IActionResult ProcessReprovar(int IdSugestao)
    {
        var originalSugestao = _db.Sugestoes.Find(IdSugestao);
        if(originalSugestao is null)
            return RedirectToAction("Index", "Home");
        originalSugestao.Estado = EnumEstadoModeracao.Reprovado;
        _db.SaveChanges();
        return RedirectToAction("Index");

        
    }
    [HttpPost]
    public IActionResult ProcessAprovar(int IdSugestao)
    {
        var originalSugestao = _db.Sugestoes.Find(IdSugestao);
        if(originalSugestao is null)
            return RedirectToAction("Index", "Home");
        originalSugestao.Estado = EnumEstadoModeracao.Aprovado;
        _db.SaveChanges();
        return RedirectToAction("Index");

        
    }
}
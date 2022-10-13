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
    [HttpGet]
    public IActionResult Create()
    {
        var genero = new Genero();
        return View(genero);
    }
    [HttpPost]
    public IActionResult Create(Genero genero)
    {
        if(!ModelState.IsValid) return View(genero);
        _db.Generos.Add(genero);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Index()
    {
        var generos = _db.Generos.ToList();
        return View(generos);
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var genero = _db.Generos.Find(id);
        if(genero is null)
            return RedirectToAction("Index");
        return View(genero);
    }
    [HttpPost]
    public IActionResult Edit(int id, Genero genero)
    {
        var generooriginal = _db.Generos.Find(id);
        if(generooriginal is null)
            return RedirectToAction("Index");
        if(!ModelState.IsValid)
            return View(genero);

        generooriginal.Nome = genero.Nome;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}
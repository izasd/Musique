using Musique.Data;
using Musique.Models;
using Microsoft.AspNetCore.Mvc;

namespace Musique.Controllers;

public class OuvinteController : Controller
{
    private readonly DataContext _db;

    public OuvinteController(DataContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var ouvintes = _db.Ouvintes.ToList();
        return View(ouvintes);
    }
    [HttpGet]
    public IActionResult Create()
    {
        var ouvinte = new Ouvinte();
        return View(ouvinte);
    }
    [HttpPost]
    public IActionResult Create(Ouvinte ouvinte)
    {
        if(!ModelState.IsValid) return View(ouvinte);
        _db.Ouvintes.Add(ouvinte);
        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var ouvinte = _db.Ouvintes.Find(id);
        if(ouvinte is null)
            return RedirectToAction("Index");
        return View(ouvinte);
    }
    [HttpPost]
    public IActionResult Edit(int id, Ouvinte ouvinte)
    {
        var ouvinteoriginal = _db.Ouvintes.Find(id);
        if(ouvinteoriginal is null)
            return RedirectToAction("Index");
        if(!ModelState.IsValid)
            return View(ouvinte);

        ouvinteoriginal.Nome = ouvinte.Nome;
        ouvinteoriginal.Email = ouvinte.Email;
        ouvinteoriginal.Senha = ouvinte.Senha;
        ouvinteoriginal.Telefone = ouvinte.Telefone;
        ouvinteoriginal.Genero = ouvinte.Genero;
        ouvinteoriginal.DataNascimento = ouvinte.DataNascimento;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}
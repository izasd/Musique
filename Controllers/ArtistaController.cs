using Musique.Data;
using Musique.Models;
using Microsoft.AspNetCore.Mvc;

namespace Musique.Controllers;

public class ArtistaController : Controller
{
    private readonly DataContext _db;

    public ArtistaController(DataContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var artistas = _db.Artistas.ToList();
        return View(artistas);
    }
    [HttpGet]
    public IActionResult Create()
    {
        var artista = new Artista();
        return View(artista);
    }
    [HttpPost]
    public IActionResult Create(Artista artista)
    {
        if(!ModelState.IsValid) return View(artista);
        _db.Artistas.Add(artista);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var artista = _db.Artistas.Find(id);
        if(artista is null)
            return RedirectToAction("Index");
        return View(artista);
    }
    [HttpPost]
    public IActionResult Edit(int id, Artista artista)
    {
        var artistaoriginal = _db.Artistas.Find(id);
        if(artistaoriginal is null)
            return RedirectToAction("Index");
        if(!ModelState.IsValid)
            return View(artista);

        artistaoriginal.Nome = artista.Nome;
        artistaoriginal.Email = artista.Email;
        artistaoriginal.Senha = artista.Senha;
        artistaoriginal.Telefone = artista.Telefone;
        artistaoriginal.Biografia = artista.Biografia;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}
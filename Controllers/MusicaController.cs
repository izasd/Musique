using Musique.Data;
using Musique.Models;
using Microsoft.AspNetCore.Mvc;

namespace Musique.Controllers;

public class MusicaController : Controller
{
    private readonly DataContext _db;

    public MusicaController(DataContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var musicas = _db.Musicas.ToList();
        return View(musicas);
    }
    [HttpGet]
    public IActionResult Create()
    {
        var musica = new Musica();
        return View(musica);
    }
    [HttpPost]
    public IActionResult Create(Musica musica)
    {
        if(!ModelState.IsValid) return View(musica);
        _db.Musicas.Add(musica);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var musica = _db.Musicas.Find(id);
        if(musica is null)
            return RedirectToAction("Index");
        return View(musica);
    }
    [HttpPost]
    public IActionResult Edit(int id, Musica musica)
    {
        var originalmusica = _db.Musicas.Find(id);
        if(originalmusica is null)
           return RedirectToAction("Index");
        if(!ModelState.IsValid){
            return View(musica);
        }            
        
        originalmusica.Nome = musica.Nome;
        originalmusica.Letra = musica.Letra;        
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var musica = _db.Musicas.Find(id);
        if(musica is null)
            return RedirectToAction("Index");
        return View(musica);
    }
    [HttpPost]
    public IActionResult ProcessDelete(int IdMusica)
    {
        var musica = _db.Musicas.Find(IdMusica);
        if(musica is null)
            return RedirectToAction("Index");
        _db.Musicas.Remove(musica);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

}
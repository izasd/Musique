using Musique.Data;
using Musique.Models;
using Microsoft.AspNetCore.Mvc;

namespace Musique.Controllers;

public class AlbumController : Controller
{
    private readonly DataContext _db;

    public AlbumController(DataContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var albuns = _db.Albuns.ToList();
        return View(albuns);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var album = new Album();
        return View(album);
    }
    [HttpPost]
    public IActionResult Create(Album album)
    {
        if(!ModelState.IsValid) return View(album);
        _db.Albuns.Add(album);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var album = _db.Albuns.Find(id);
        if(album is null)
            return RedirectToAction("Index");
        return View(album);
    }
    [HttpPost]
    public IActionResult Edit(int id, Album album)
    {
        var originalalbum = _db.Albuns.Find(id);
        if(originalalbum is null)
           return RedirectToAction("Index");
        if(!ModelState.IsValid){
            return View(album);
        }            
        
        originalalbum.Nome = album.Nome;     
        originalalbum.DataLancamento = album.DataLancamento;     
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var album = _db.Albuns.Find(id);
        if(album is null)
            return RedirectToAction("Index");
        return View(album);
    }
    [HttpPost]
    public IActionResult ProcessDelete(int IdAlbum)
    {
        var album = _db.Albuns.Find(IdAlbum);
        if(album is null)
            return RedirectToAction("Index");
        _db.Albuns.Remove(album);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

}
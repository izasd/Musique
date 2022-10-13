using Musique.Data;
using Musique.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Musique.Controllers;

public class GravacaoController : Controller
{
    private readonly DataContext _db;

    public GravacaoController(DataContext db)
    {
        _db = db;
    }

    private void LoadGeneros(int? idSelectedGenero = null)
    {
        var generos = _db.Generos.ToList();
        var selectGeneros = new SelectList(generos, "IdGenero", "Nome", idSelectedGenero);
        ViewBag.SelectGeneros = selectGeneros;
    }
    private void LoadAlbuns(int? idSelectedAlbum = null)
    {
        var generos = _db.Albuns.ToList();
        var selectAlbuns = new SelectList(generos, "IdAlbum", "Nome", idSelectedAlbum);
        ViewBag.SelectAlbuns = selectAlbuns;
    }
    private void LoadArtistas(int? idSelectedArtista = null)
    {
        var artistas = _db.Artistas.ToList();
        var selectArtistas = new SelectList(artistas, "IdUsuario", "Nome", idSelectedArtista);
        ViewBag.SelectArtistas = selectArtistas;
    }
    private void LoadMusicas(int? idSelectedMusica = null)
    {
        var musicas = _db.Musicas.ToList();
        var selectMusicas = new SelectList(musicas, "IdMusica", "Nome", idSelectedMusica);
        ViewBag.SelectMusicas = selectMusicas;
    }

    public IActionResult Index()
    {
        var gravacoes = _db.Gravacoes.Include(a=>a.Artista).Include(a=>a.Musica).ToList();
        return View(gravacoes);
    }
    public IActionResult Details(int IdGravacao)
    {
        var gravacao = _db.Gravacoes.FirstOrDefault(gr => gr.IdGravacao == IdGravacao);
        return View(gravacao);
    }
    [HttpGet]
    public IActionResult Create()
    {
        LoadArtistas();
        LoadGeneros();
        LoadMusicas();
        LoadAlbuns();
        var gravacao = new Gravacao();
        return View(gravacao);
    }
    [HttpPost]
    public IActionResult Create(Gravacao gravacao)
    {
        if(!ModelState.IsValid){
            LoadArtistas(gravacao.IdArtista);
            LoadGeneros(gravacao.IdGenero);
            LoadMusicas(gravacao.IdMusica);
            LoadAlbuns(gravacao.IdAlbum);
            return View(gravacao);
        } 
        _db.Gravacoes.Add(gravacao);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var gravacao = _db.Gravacoes.Find(id);
        if(gravacao is null)
            return RedirectToAction("Index");
        LoadArtistas(gravacao.IdArtista);
        LoadGeneros(gravacao.IdGenero);
        LoadMusicas(gravacao.IdMusica);
        LoadAlbuns(gravacao.IdAlbum);
        return View(gravacao);
    }
    [HttpPost]
    public IActionResult Edit(int id, Gravacao gravacao)
    {
        var gravacaooriginal = _db.Gravacoes.Find(id);
        if(gravacaooriginal is null)
            return RedirectToAction("Index");
        if(!ModelState.IsValid){
            LoadArtistas(gravacao.IdArtista);
            LoadGeneros(gravacao.IdGenero);
            LoadMusicas(gravacao.IdMusica);
            LoadAlbuns(gravacao.IdAlbum);
            return View(gravacao);
        }
        gravacaooriginal.IdAlbum = gravacao.IdAlbum;
        gravacaooriginal.IdArtista = gravacao.IdArtista;
        gravacaooriginal.DataLancamento = gravacao.DataLancamento;
        gravacaooriginal.Duracao = gravacao.Duracao;
        gravacaooriginal.IdGenero = gravacao.IdGenero;
        gravacaooriginal.IdMusica = gravacao.IdMusica;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var gravacao = _db.Gravacoes.Find(id);
        if(gravacao is null)
            return RedirectToAction("Index");
        return View(gravacao);
    }
    [HttpPost]
    public IActionResult ProcessDelete(int IdGravacao)
    {
        var gravacao = _db.Gravacoes.Find(IdGravacao);
        if(gravacao is null)
            return RedirectToAction("Index");
        _db.Gravacoes.Remove(gravacao);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

}
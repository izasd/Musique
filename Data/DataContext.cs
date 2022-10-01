
using Microsoft.EntityFrameworkCore;
using Musique.Models;

namespace Musique.Data;

public class DataContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Sugestao> Sugestoes { get; set; }
    public DbSet<Album> Albuns { get; set; }
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Avaliacao> Avaliacoes { get; set; }
    public DbSet<Denuncia> Denuncias { get; set; }
    public DbSet<Genero> Generos { get; set; }
    public DbSet<Gravacao> Gravacoes { get; set; }
    public DbSet<Moderador> Moderadores { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    public DbSet<Ouvinte> Ouvintes { get; set; }
    public DbSet<Seguidores> TblSeguidores { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        // mb.Entity<Avaliacao>().HasKey(ip => new { ip.IdOuvinte });
        // mb.Entity<Denuncia>().HasKey(ip => new { ip.IdAvaliacao });
        // mb.Entity<Denuncia>().HasKey(ip => new { ip.IdOuvinte });
        // mb.Entity<Gravacao>().HasKey(ip => new { ip.IdArtista });
        // mb.Entity<Gravacao>().HasKey(ip => new { ip.IdGenero });
        // mb.Entity<Gravacao>().HasKey(ip => new { ip.IdMusica });
        // mb.Entity<Gravacao>().HasKey(ip => new { ip.IdAlbum });
        mb.Entity<Seguidores>().HasKey(ip => new { ip.IdSeguido });
    }
    public DataContext(DbContextOptions<DataContext> options) : base(options){}
}
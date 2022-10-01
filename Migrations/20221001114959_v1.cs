using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Musique.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albuns",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albuns", x => x.IdAlbum);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.IdGenero);
                });

            migrationBuilder.CreateTable(
                name: "Musicas",
                columns: table => new
                {
                    IdMusica = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Letra = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicas", x => x.IdMusica);
                });

            migrationBuilder.CreateTable(
                name: "TblSeguidores",
                columns: table => new
                {
                    IdSeguido = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdSeguidor = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSeguidores", x => x.IdSeguido);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Senha = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Biografia = table.Column<string>(type: "TEXT", maxLength: 300, nullable: true),
                    Tipo = table.Column<string>(type: "TEXT", nullable: true),
                    Genero = table.Column<string>(type: "TEXT", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    OuvintesSeguidos = table.Column<int>(type: "INTEGER", nullable: true),
                    Seguidores = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "AlbumArtista",
                columns: table => new
                {
                    AlbunsIdAlbum = table.Column<int>(type: "INTEGER", nullable: false),
                    ArtistasIdUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumArtista", x => new { x.AlbunsIdAlbum, x.ArtistasIdUsuario });
                    table.ForeignKey(
                        name: "FK_AlbumArtista_Albuns_AlbunsIdAlbum",
                        column: x => x.AlbunsIdAlbum,
                        principalTable: "Albuns",
                        principalColumn: "IdAlbum",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumArtista_Usuarios_ArtistasIdUsuario",
                        column: x => x.ArtistasIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gravacoes",
                columns: table => new
                {
                    IdGravacao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataLancamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Duracao = table.Column<double>(type: "REAL", nullable: false),
                    IdArtista = table.Column<int>(type: "INTEGER", nullable: false),
                    IdGenero = table.Column<int>(type: "INTEGER", nullable: false),
                    IdMusica = table.Column<int>(type: "INTEGER", nullable: false),
                    IdAlbum = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gravacoes", x => x.IdGravacao);
                    table.ForeignKey(
                        name: "FK_Gravacoes_Albuns_IdAlbum",
                        column: x => x.IdAlbum,
                        principalTable: "Albuns",
                        principalColumn: "IdAlbum",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gravacoes_Generos_IdGenero",
                        column: x => x.IdGenero,
                        principalTable: "Generos",
                        principalColumn: "IdGenero",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gravacoes_Musicas_IdMusica",
                        column: x => x.IdMusica,
                        principalTable: "Musicas",
                        principalColumn: "IdMusica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gravacoes_Usuarios_IdArtista",
                        column: x => x.IdArtista,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sugestoes",
                columns: table => new
                {
                    IdSugestao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeMusica = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    NomeArtista = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    IdOuvinte = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sugestoes", x => x.IdSugestao);
                    table.ForeignKey(
                        name: "FK_Sugestoes_Usuarios_IdOuvinte",
                        column: x => x.IdOuvinte,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    IdAvaliacao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Classificacao = table.Column<int>(type: "INTEGER", nullable: false),
                    Comentario = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    IdOuvinte = table.Column<int>(type: "INTEGER", nullable: false),
                    GravacaoIdGravacao = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.IdAvaliacao);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Gravacoes_GravacaoIdGravacao",
                        column: x => x.GravacaoIdGravacao,
                        principalTable: "Gravacoes",
                        principalColumn: "IdGravacao");
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Usuarios_IdOuvinte",
                        column: x => x.IdOuvinte,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Denuncias",
                columns: table => new
                {
                    IdDenuncia = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OpcMotivo = table.Column<string>(type: "TEXT", nullable: false),
                    TextoMotivo = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    IdAvaliacao = table.Column<int>(type: "INTEGER", nullable: false),
                    IdOuvinte = table.Column<int>(type: "INTEGER", nullable: false),
                    DenuncianteIdUsuario = table.Column<int>(type: "INTEGER", nullable: true),
                    ModeradorIdUsuario = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denuncias", x => x.IdDenuncia);
                    table.ForeignKey(
                        name: "FK_Denuncias_Avaliacoes_IdAvaliacao",
                        column: x => x.IdAvaliacao,
                        principalTable: "Avaliacoes",
                        principalColumn: "IdAvaliacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Denuncias_Usuarios_DenuncianteIdUsuario",
                        column: x => x.DenuncianteIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                    table.ForeignKey(
                        name: "FK_Denuncias_Usuarios_ModeradorIdUsuario",
                        column: x => x.ModeradorIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumArtista_ArtistasIdUsuario",
                table: "AlbumArtista",
                column: "ArtistasIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_GravacaoIdGravacao",
                table: "Avaliacoes",
                column: "GravacaoIdGravacao");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_IdOuvinte",
                table: "Avaliacoes",
                column: "IdOuvinte");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_DenuncianteIdUsuario",
                table: "Denuncias",
                column: "DenuncianteIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_IdAvaliacao",
                table: "Denuncias",
                column: "IdAvaliacao");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_ModeradorIdUsuario",
                table: "Denuncias",
                column: "ModeradorIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Gravacoes_IdAlbum",
                table: "Gravacoes",
                column: "IdAlbum");

            migrationBuilder.CreateIndex(
                name: "IX_Gravacoes_IdArtista",
                table: "Gravacoes",
                column: "IdArtista");

            migrationBuilder.CreateIndex(
                name: "IX_Gravacoes_IdGenero",
                table: "Gravacoes",
                column: "IdGenero");

            migrationBuilder.CreateIndex(
                name: "IX_Gravacoes_IdMusica",
                table: "Gravacoes",
                column: "IdMusica");

            migrationBuilder.CreateIndex(
                name: "IX_Sugestoes_IdOuvinte",
                table: "Sugestoes",
                column: "IdOuvinte");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumArtista");

            migrationBuilder.DropTable(
                name: "Denuncias");

            migrationBuilder.DropTable(
                name: "Sugestoes");

            migrationBuilder.DropTable(
                name: "TblSeguidores");

            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "Gravacoes");

            migrationBuilder.DropTable(
                name: "Albuns");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Musicas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}

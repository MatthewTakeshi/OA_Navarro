using OA_Teste_Sozinho.Shared;
using Microsoft.EntityFrameworkCore;

namespace OA_Teste_Sozinho.Server
{
     public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Vazio Mesmo
        }
        public DbSet<Game> Jogos { get; set; }
        public DbSet<Plataforma> Plataformas { get; set;}
        public DbSet<Genero> Generos { get; set; }
        
    }
}
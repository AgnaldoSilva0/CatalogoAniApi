using CatalogoAniApi.Modelo.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CatalogoAniApi.Repositorio
{
    public class Contexto : DbContext
    {
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Log> Logs { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Repository.Filmes;
using Repository.Generos;
using Repository.Locacoes;

namespace Repository
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FilmeConfig());
            modelBuilder.ApplyConfiguration(new GeneroConfig());
            modelBuilder.ApplyConfiguration(new LocacaoConfig());
            modelBuilder.ApplyConfiguration(new LocacaoFilmeConfig());
        }
    }
}
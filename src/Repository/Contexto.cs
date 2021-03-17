using Microsoft.EntityFrameworkCore;
using Repository.Filmes;

namespace Repository
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FilmeConfig());
        }
    }
}
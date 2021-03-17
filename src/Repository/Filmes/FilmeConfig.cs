using Domain.Filmes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Filmes
{
    public class FilmeConfig : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.HasKey(p => p.CodigoFilme);            

            builder.Property(p => p.CodigoFilme)                   
                   .HasColumnName("ID")
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
                    .HasColumnName("NOME")
                    .HasMaxLength(200)
                    .IsRequired();
                    
            builder.Property(p => p.DataCriacao)
                    .HasColumnName("DATACRIACAO")
                    .IsRequired();
                    
            builder.Property(p => p.Ativo)
                    .HasColumnName("ATIVO")
                    .IsRequired();
                    
            builder.Property(p => p.CodigoGenero)
                    .HasColumnName("IDGENERO")
                    .IsRequired();
        }
    }
}
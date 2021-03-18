using Domain.Generos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Generos
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.HasKey(p => p.CodigoGenero);            

            builder.Property(p => p.CodigoGenero)                   
                   .HasColumnName("ID")
                   .IsRequired()
                   .ValueGeneratedOnAdd(); 

            builder.Property(p => p.Nome)
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsRequired();
                    
            builder.Property(p => p.DataCriacao)
                    .HasColumnName("DATACRIACAO")
                    .IsRequired();
                    
            builder.Property(p => p.Ativo)
                    .HasColumnName("ATIVO")
                    .IsRequired();                                                  
        }
    }
}
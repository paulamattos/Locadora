using Domain.Locacoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Locacoes
{
    public class LocacaoConfig
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {         
            builder.HasKey(p => p.CodigoLocacao);            
               
            builder.Property(p => p.CodigoLocacao)                   
                   .HasColumnName("ID")
                   .IsRequired()
                   .ValueGeneratedOnAdd(); 

                builder.Property(p => p.CPF)
                    .HasColumnName("CPF")
                    .HasMaxLength(14)
                    .IsRequired();                   

                builder.Property(p => p.DataLocacao)
                    .HasColumnName("DATALOCACAO")
                    .IsRequired();
        }
    }
}
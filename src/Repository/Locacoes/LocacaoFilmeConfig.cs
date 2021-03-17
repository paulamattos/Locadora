using Domain.Locacoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Locacoes
{
    public class LocacaoFilmeConfig
    {
        public void Configure(EntityTypeBuilder<LocacaoFilme> builder)
        {
            builder.HasKey(p => new {p.CodigoLocacao, p.CodigoFilme});

            builder.Property(p => p.CodigoLocacao)                   
                   .HasColumnName("IDLOCACAO")
                   .IsRequired();                    

            builder.Property(p => p.CodigoLocacao)                   
                   .HasColumnName("IDFILME")
                   .IsRequired();                                       
        }
    }
}
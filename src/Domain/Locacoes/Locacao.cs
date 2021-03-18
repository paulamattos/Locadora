using System;
using System.Collections.Generic;

namespace Domain.Locacoes
{
    public class Locacao
    {
        public int CodigoLocacao { get; set; }
        public string CPF { get; set; }
        public DateTime DataLocacao { get; set; }
        
        public virtual List<LocacaoFilme> Filmes { get; set; }
    }
}
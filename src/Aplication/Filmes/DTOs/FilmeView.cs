using System;

namespace Aplication.Filmes.DTOs
{
    public class FilmeView
    {
        public int CodigoFilme { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
        public int CodigoGenero { get; set; } 
    }
}
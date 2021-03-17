using System;

namespace Domain.Generos
{
    public class Genero
    {
        public int CodigoGenero { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}
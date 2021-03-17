using System;

namespace Aplication.Generos.DTOs
{
    public class EditarGeneroDTO
    {
        public int CodigoGenero { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}
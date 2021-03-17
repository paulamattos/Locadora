namespace Aplication.Filmes.DTOs
{
    public class EditarFilmeDTO
    {
        public int CodigoFilme { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public int CodigoGenero { get; set; }
    }
}
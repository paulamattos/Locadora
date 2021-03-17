using System;
using System.Collections.Generic;

namespace Aplication.Locacoes.DTOs
{
    public class EditarLocacaoDTO
    {
        public int CodigoLocacao { get; set; }
        public string CPF { get; set; }
        public DateTime DataLocacao { get; set; }

        public List<LocacaoFilmesDTO> Filmes { get; set; }
    }
}
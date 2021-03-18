using System;
using System.Collections.Generic;

namespace Aplication.Locacoes.DTOs
{
    public class InserirLocacaoDTO
    {
        public string CPF { get; set; }        

        public List<LocacaoFilmesDTO> Filmes { get; set; }
    }
}
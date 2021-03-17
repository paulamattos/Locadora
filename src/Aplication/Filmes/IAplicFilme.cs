using System.Collections.Generic;
using Aplication.Filmes.DTOs;

namespace Aplication.Filmes
{
    public interface IAplicFilme
    {
        int Inserir(InserirFilmeDTO dto);
        void Editar(EditarFilmeDTO dto);
        List<FilmeView> ListarFilmes();
        void Remover(int codigoFilme);
        void RemoverFilmes(List<int> ids);
    }
}
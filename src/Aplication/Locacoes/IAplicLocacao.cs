using System.Collections.Generic;
using Aplication.Locacoes.DTOs;

namespace Aplication.Locacoes
{
    public interface IAplicLocacao
    {
        int Inserir(InserirLocacaoDTO dto);
        void Editar(EditarLocacaoDTO dto);
        List<LocacaoView> Listar();
    }
}
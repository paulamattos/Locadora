using System.Collections.Generic;
using System.Linq;

namespace Domain.Locacoes
{
    public interface IRepLocacao
    {
        int Inserir(Locacao Locacao);
        void Remover(Locacao Locacao);
        IQueryable<Locacao> Listar();
        Locacao RecuperarPorId(int id);
        void InserirFilme(LocacaoFilme LocacaoFilme);
        List<LocacaoFilme> RecuperarFilmesLocacao(int codigoLocacao);
        void RemoverFilmes(List<LocacaoFilme> locacaoFilmes);
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Domain.Filmes
{
    public interface IRepFilme
    {
        int Inserir(Filme filme);
        void Remover(Filme filme);
        IQueryable<Filme> Listar();
        Filme RecuperarPorId(int id);
        List<Filme> Recuperar(List<int> ids);
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Domain.Generos
{
    public interface IRepGenero
    {
        int Inserir(Genero Genero);
        void Remover(Genero Genero);
        void Remover(List<int> ids);
        IQueryable<Genero> Listar();
        Genero RecuperarPorId(int id);
        List<Genero> Recuperar(List<int> ids);
    }
}
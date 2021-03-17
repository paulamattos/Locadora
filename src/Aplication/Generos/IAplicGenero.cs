using System.Collections.Generic;
using Aplication.Generos.DTOs;

namespace Aplication.Generos
{
    public interface IAplicGenero
    {
        int Inserir(InserirGeneroDTO dto);
        void Editar(EditarGeneroDTO dto);
        List<GeneroView> Listar();
        void Remover(int codigoGenero);
        void RemoverGeneros(List<int> IdsGeneros);
    }
}
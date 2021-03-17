using System.Collections.Generic;
using System.Linq;
using Domain.Filmes;

namespace Repository.Filmes
{
    public class RepFilme : IRepFilme
    {
        private readonly Contexto _contexto;

        public RepFilme(Contexto contexto)
        {
            _contexto = contexto;
        }

        public int Inserir(Filme filme)
        {
            _contexto.Add(filme);            

            return filme.CodigoFilme;
        }        

        public void Remover(Filme filme)
        {
            _contexto.Remove(filme);
        }

        public IQueryable<Filme> Listar()
        {
            return _contexto.Set<Filme>();
        }

        public Filme RecuperarPorId(int id){
            return _contexto.Set<Filme>().Where(p => p.CodigoFilme == id).FirstOrDefault();
        }

        public List<Filme> Recuperar(List<int> ids)
        {
            return _contexto.Set<Filme>().Where(p => ids.Contains(p.CodigoFilme)).ToList();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Domain.Generos;

namespace Repository.Generos
{
    public class RepGenero : IRepGenero
    {
        private readonly Contexto _contexto;

        public RepGenero(Contexto contexto)
        {
            _contexto = contexto;
        }

        public int Inserir(Genero Genero)
        {
            _contexto.Add(Genero);            

            return Genero.CodigoGenero;
        }        

        public void Remover(Genero Genero)
        {
            _contexto.Remove(Genero);
        }        

        public void Remover(List<int> ids)
        {
            _contexto.RemoveRange(Recuperar(ids));
        }        

        public IQueryable<Genero> Listar()
        {
            return _contexto.Set<Genero>();
        }

        public Genero RecuperarPorId(int id){
            return _contexto.Set<Genero>().Where(p => p.CodigoGenero == id).FirstOrDefault();
        }

        public List<Genero> Recuperar(List<int> ids)
        {
            return _contexto.Set<Genero>().Where(p => ids.Contains(p.CodigoGenero)).ToList();
        }
    }
}
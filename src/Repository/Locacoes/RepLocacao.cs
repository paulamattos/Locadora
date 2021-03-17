using System.Linq;
using Domain.Locacoes;

namespace Repository.Locacaos
{
    public class RepLocacao : IRepLocacao
    {
        private readonly Contexto _contexto;

        public RepLocacao(Contexto contexto)
        {
            _contexto = contexto;
        }

        public int Inserir(Locacao Locacao)
        {
            _contexto.Add(Locacao);            

            return Locacao.CodigoLocacao;
        }        

        public void Remover(Locacao Locacao)
        {
            _contexto.Remove(Locacao);
        }

        public IQueryable<Locacao> Listar()
        {
            return _contexto.Set<Locacao>();
        }

        public Locacao RecuperarPorId(int id){
            return _contexto.Set<Locacao>().Where(p => p.CodigoLocacao == id).FirstOrDefault();
        }
    }
}
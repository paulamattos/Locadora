using Domain.Base;

namespace Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Contexto _contexto;

        public UnitOfWork(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }
    }
}
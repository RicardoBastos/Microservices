using Core.Infra.Interface;
using Seguranca.Infra.Context;

namespace Seguranca.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SegurancaContext _context;

        public UnitOfWork(SegurancaContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

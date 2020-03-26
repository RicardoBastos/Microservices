using Core.Infra.Interface;
using RH.Infra.Context;

namespace RH.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RHContext _context;

        public UnitOfWork(RHContext context)
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

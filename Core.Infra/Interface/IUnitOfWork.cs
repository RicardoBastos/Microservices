using System;

namespace Core.Infra.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}

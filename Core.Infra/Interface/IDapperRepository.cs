using System;
using System.Collections.Generic;

namespace Core.Infra.Interface
{
    public interface IDapperRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
    }
}

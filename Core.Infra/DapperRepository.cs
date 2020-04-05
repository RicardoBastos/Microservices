using Core.Infra.Interface;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Core.Infra
{
    public abstract class DapperRepositoryBase<TEntity> : IDapperRepository<TEntity> where TEntity : class
    {
        private readonly IConfiguration _configuration;
        protected readonly SqlConnection conn;

        public DapperRepositoryBase(IConfiguration configuration)
        {
            _configuration = configuration;
            conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        public virtual IEnumerable<TEntity> GetAll() =>
            conn.GetAll<TEntity>();

        public virtual TEntity GetById(Guid id) =>
            conn.Get<TEntity>(id);


        private bool _disposed = false;

        ~DapperRepositoryBase() =>
            Dispose();

        public void Dispose()
        {
            if (!_disposed)
            {
                conn.Close();
                conn.Dispose();
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }

    }
}

using Core.Infra.Interface;
using Microsoft.EntityFrameworkCore;
using RH.Infra.Context;
using System;
using System.Collections.Generic;

namespace RH.Infra.Repository
{
    public class Repository<TEntity> : IDapperRepository<TEntity> where TEntity : class
    {
        protected readonly RHContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(RHContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

       
    }
}

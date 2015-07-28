using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SaleAssistant.Data;
using SaleAssistant.Data.Entities;

namespace SaleAssistant.DataAccess
{
    public interface IEntityDA<TEntity>
    {
        IList<TEntity> GetAll();
        TEntity GetById(Guid id);
        void Insert(TEntity item);
        void Delete(Guid id);
        void Update(TEntity item);
        void Save();
    }

    public abstract class EntityDA<TEntity> : IEntityDA<TEntity> where TEntity : Entity
    {
        private readonly SaleAssistantDbContext dbContext;

        protected DbSet<TEntity> DbSet { get; set; }

        protected EntityDA(SaleAssistantDbContext context)
        {
            dbContext = context;
            DbSet = dbContext.Set<TEntity>();
        }

        public IList<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Insert(TEntity item)
        {
            DbSet.Add(item);
        }

        public void Delete(Guid id)
        {
            TEntity product = DbSet.Find(id);
            DbSet.Remove(product);
        }

        public void Update(TEntity item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
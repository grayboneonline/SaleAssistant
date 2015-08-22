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
        TEntity GetById(int id);
        void Insert(TEntity item);
        void Delete(TEntity item);
        void Update(TEntity item);
        void Save();
    }

    public abstract class EntityDA<TEntity> : IEntityDA<TEntity> where TEntity : class, IEntity
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

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Insert(TEntity item)
        {
            DbSet.Add(item);
        }

        public void Delete(TEntity item)
        {
            DbSet.Remove(item);
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
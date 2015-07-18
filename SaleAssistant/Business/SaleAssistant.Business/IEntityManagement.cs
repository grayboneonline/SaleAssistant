using AutoMapper;
using System;
using System.Collections.Generic;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface IEntityManagement<TModel>
    {
        IList<TModel> GetAll();
        TModel GetById(Guid id);
        void Insert(TModel item);
        void Delete(Guid id);
        void Update(TModel item);
        void Save();
    }

    public abstract class EntityManagement<TEntity, TModel, TDA> : IEntityManagement<TModel>
        where TEntity : class
        where TModel : class
        where TDA : IEntityDA<TEntity>
    {
        protected TDA DA { get; set; }

        protected EntityManagement(TDA da)
        {
            DA = da;
        }

        public IList<TModel> GetAll()
        {
            return Mapper.Map<IList<TModel>>(DA.GetAll());
        }

        public TModel GetById(Guid id)
        {
            return Mapper.Map<TModel>(DA.GetById(id));
        }

        public void Insert(TModel item)
        {
            DA.Insert(Mapper.Map<TEntity>(item));
        }

        public void Delete(Guid id)
        {
            DA.Delete(id);
        }

        public void Update(TModel item)
        {
            DA.Update(Mapper.Map<TEntity>(item));
        }

        public void Save()
        {
            DA.Save();
        }
    }
}
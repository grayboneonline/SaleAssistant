using AutoMapper;
using System;
using System.Collections.Generic;
using SaleAssistant.Business.Models;
using SaleAssistant.Data.Entities;
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
    }

    public abstract class EntityManagement<TEntity, TModel, TDA> : IEntityManagement<TModel>
        where TEntity : IEntity
        where TModel : IBusinessModel
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
            DA.Save();
        }

        public void Delete(Guid id)
        {
            DA.Delete(id);
            DA.Save();
        }

        public void Update(TModel item)
        {
            TEntity entity = DA.GetById(item.Id);
            Mapper.Map(item, entity);
            DA.Update(entity);
            DA.Save();
        }
    }
}
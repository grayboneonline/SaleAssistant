using System.Linq;
using System.Net;
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
        IList<ServiceError> Delete(Guid id);
        IList<ServiceError> Update(TModel item);
    }

    public abstract class EntityManagement<TEntity, TModel, TDA> : IEntityManagement<TModel>
        where TEntity : class, IEntity
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

        public IList<ServiceError> Delete(Guid id)
        {
            IList<ServiceError> errors = new List<ServiceError>();
            TEntity entity = DA.GetById(id);

            if (entity == null)
                errors.Add(new ServiceError { FieldKey = "Id", Message = "", StatusCode = HttpStatusCode.NotFound });

            if (!errors.Any())
            {
                DA.Delete(entity);
                DA.Save();
            }
            return errors;
        }

        public IList<ServiceError> Update(TModel item)
        {
            IList<ServiceError> errors = new List<ServiceError>();
            TEntity entity = DA.GetById(item.Id);

            if (entity == null)
                errors.Add(new ServiceError { FieldKey = "Id", Message = "", StatusCode = HttpStatusCode.NotFound });

            if (!errors.Any())
            {
                Mapper.Map(item, entity);
                DA.Update(entity);
                DA.Save();
            }
            return errors;
        }
    }
}
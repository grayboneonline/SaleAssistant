using System.Linq;
using System.Net;
using System;
using System.Collections.Generic;
using SaleAssistant.AutoMapper;
using SaleAssistant.Business.Models;
using SaleAssistant.Data.Entities;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface IEntityManagement<TModel>
    {
        IList<TModel> GetAll(bool visible = false, bool relationVisible = false);
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

        public virtual IList<TModel> GetAll(bool visible, bool relationVisible)
        {
            IEnumerable<TEntity> list = DA.GetAll();
            if (visible)
                list = list.Where(x => x.IsVisible);
            if (relationVisible)
                list = list.Where(x => x.IsRelationVisible);

            return list.MapTo<IList<TModel>>();
        }

        public virtual TModel GetById(Guid id)
        {
            return DA.GetById(id).MapTo<TModel>();
        }

        public virtual void Insert(TModel item)
        {
            DA.Insert(item.MapTo<TEntity>());
            DA.Save();
        }

        public virtual IList<ServiceError> Delete(Guid id)
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

        public virtual IList<ServiceError> Update(TModel item)
        {
            IList<ServiceError> errors = new List<ServiceError>();
            TEntity entity = DA.GetById(item.Id);

            if (entity == null)
                errors.Add(new ServiceError { FieldKey = "Id", Message = "", StatusCode = HttpStatusCode.NotFound });

            if (!errors.Any())
            {
                item.MapTo(entity);
                DA.Update(entity);
                DA.Save();
            }
            return errors;
        }
    }
}
using System.Net;
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
        TModel GetById(int id);
        void Insert(TModel item);
        IList<ServiceError> Delete(int id);
        IList<ServiceError> Update(TModel item);
    }

    public interface IEntityWithStatusManagement
    {
        IList<ServiceError> SetStatus(int id, Models.Status status);
    }

    public interface IEntityWithIsDeletedManagement
    {
        IList<ServiceError> SetDeletedStatus(int id, bool isDeleted);
    }

    public abstract class EntityManagement<TEntity, TModel, TDA>
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
            //if (visible)
            //    list = list.Where(x => x.IsVisible);
            //if (relationVisible)
            //    list = list.Where(x => x.IsRelationVisible);

            return list.MapTo<IList<TModel>>();
        }

        public virtual TModel GetById(int id)
        {
            return DA.GetById(id).MapTo<TModel>();
        }

        public virtual void Insert(TModel item)
        {
            DA.Insert(item.MapTo<TEntity>());
            DA.Save();
        }

        public virtual IList<ServiceError> Delete(int id)
        {
            IList<ServiceError> errors = new List<ServiceError>();
            TEntity entity = DA.GetById(id);

            if (entity == null)
                errors.Add(new ServiceError { FieldKey = "Id", Message = "", StatusCode = HttpStatusCode.NotFound });
            else
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
            else
            {
                item.MapTo(entity);
                DA.Update(entity);
                DA.Save();
            }
            return errors;
        }

        public virtual IList<ServiceError> SetStatus(int id, Models.Status status)
        {
            IList<ServiceError> errors = new List<ServiceError>();
            TEntity entity = DA.GetById(id);
            IEntityWithStatus entityWithStatus = entity as IEntityWithStatus;

            if (entityWithStatus == null)
                errors.Add(new ServiceError {FieldKey = "", Message = "Setting status error", StatusCode = HttpStatusCode.BadRequest});
            else
            {
                entityWithStatus.Status = (Data.Entities.Status) status;
                DA.Update((TEntity)entityWithStatus);
                DA.Save();
            }
            return errors;
        }

        public virtual IList<ServiceError> SetDeletedStatus(int id, bool isDeleted)
        {
            IList<ServiceError> errors = new List<ServiceError>();
            TEntity entity = DA.GetById(id);
            IEntityWithIsDeleted entityWithStatus = entity as IEntityWithIsDeleted;

            if (entityWithStatus == null)
                errors.Add(new ServiceError { FieldKey = "", Message = "Deleting error", StatusCode = HttpStatusCode.BadRequest });
            else
            {
                entityWithStatus.IsDeleted = isDeleted;
                DA.Update((TEntity)entityWithStatus);
                DA.Save();
            }
            return errors;
        }
    }
}
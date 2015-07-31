using System;
using System.Collections.Generic;
using System.Net;
using SaleAssistant.Business.Models;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface IUnitManagement : IEntityManagement<Unit>
    {
        IList<ServiceError> SetStatus(Guid id, Status status);
        IList<ServiceError> SetTrashStatus(Guid id, bool isTrash);
    }

    public class UnitManagement : EntityManagement<Data.Entities.Unit, Unit, IUnitDA>, IUnitManagement
    {
        public UnitManagement(IUnitDA da)
            : base(da)
        {
        }

        public IList<ServiceError> SetStatus(Guid id, Status status)
        {
            IList<ServiceError> errors = new List<ServiceError>();
            Data.Entities.Unit unit = DA.GetById(id);

            if (unit == null)
                errors.Add(new ServiceError { FieldKey = "Id", Message = "", StatusCode = HttpStatusCode.NotFound });
            else
            {
                unit.Status = (Data.Entities.Status)status;
                DA.Update(unit);
                DA.Save();
            }
            return errors;
        }

        public IList<ServiceError> SetTrashStatus(Guid id, bool isTrash)
        {
            IList<ServiceError> errors = new List<ServiceError>();
            Data.Entities.Unit unit = DA.GetById(id);

            if (unit == null)
                errors.Add(new ServiceError { FieldKey = "Id", Message = "", StatusCode = HttpStatusCode.NotFound });
            else
            {
                unit.IsTrash = isTrash;
                DA.Update(unit);
                DA.Save();
            }
            return errors;
        }
    }
}

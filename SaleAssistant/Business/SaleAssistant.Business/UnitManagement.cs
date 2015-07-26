using System;
using SaleAssistant.Business.Models;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface IUnitManagement : IEntityManagement<Unit>
    {
        void SetStatus(Guid id, Status status);
        void SetTrashStatus(Guid id, bool isTrash);
    }

    public class UnitManagement : EntityManagement<Data.Entities.Unit, Unit, IUnitDA>, IUnitManagement
    {
        public UnitManagement(IUnitDA da)
            : base(da)
        {
        }

        public void SetStatus(Guid id, Status status)
        {
            Data.Entities.Unit unit = DA.GetById(id);
            unit.Status = (Data.Entities.Status) status;
            DA.Update(unit);
            DA.Save();
        }

        public void SetTrashStatus(Guid id, bool isTrash)
        {
            Data.Entities.Unit unit = DA.GetById(id);
            unit.IsTrash = isTrash;
            DA.Update(unit);
            DA.Save();
        }
    }
}

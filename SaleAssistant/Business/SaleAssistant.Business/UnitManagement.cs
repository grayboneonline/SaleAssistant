﻿using SaleAssistant.Business.Models;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public interface IUnitManagement : IEntityManagement<Unit>
    {
    }

    public class UnitManagement : EntityManagement<Data.Entities.Unit, Unit, IUnitDA>, IUnitManagement
    {
        public UnitManagement(IUnitDA da)
            : base(da)
        {
        }
    }
}

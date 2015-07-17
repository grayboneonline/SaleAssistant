﻿using Autofac;
using SaleAssistant.Data;

namespace SaleAssistant.DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ProductDA(c.Resolve<SaleAssistantDbContext>())).As<IProductDA>().SingleInstance();
        }
    }
}
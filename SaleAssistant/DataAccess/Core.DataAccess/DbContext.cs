﻿namespace Core.DataAccess
{
    public class DbContext : System.Data.Entity.DbContext
    {
        protected IConfig config;

        public DbContext(IConfig config)
            : base(config.ConnectionString)
        {
            this.config = config;
        }
    }
}

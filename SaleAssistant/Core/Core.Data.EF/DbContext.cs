namespace Core.Data.EF
{
    public class DbContext : System.Data.Entity.DbContext
    {
        protected IConfig Config { get; private set; }

        public DbContext(IConfig config)
            : base(config.ConnectionString)
        {
            Config = config;
        }
    }
}

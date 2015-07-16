namespace SaleAssistant.Data
{
    public interface IConfig
    {
        string ConnectionString { get; set; }
    }

    public class Config : IConfig
    {
        public string ConnectionString { get; set; }

        public static IConfig DevEnvironment
        {
            get { return new Config { ConnectionString = "Data Source=.;Initial Catalog=SaleAssistant;User ID=sa;Password=sa123" }; }
        }
    }
}

using System;

namespace Core.DataAccess
{
    public interface IConfig
    {
        string ConnectionString { get; set; }
    }
}

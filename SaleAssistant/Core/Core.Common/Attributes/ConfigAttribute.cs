using System;
using System.Configuration;
using System.Reflection;

namespace Core.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigAttribute : Attribute
    {
        public ConfigType Type { get; set; }
        public string Key { get; set; }

        public ConfigAttribute(string key, ConfigType type = ConfigType.AppSetting)
        {
            Key = key;
            Type = type;
        }

        public static void ReadConfigForType(Type t)
        {
            PropertyInfo[] staticProps = t.GetProperties();
            foreach (PropertyInfo prop in staticProps)
            {
                ConfigAttribute attribute = prop.GetCustomAttribute<ConfigAttribute>();
                if (attribute != null)
                {
                    if (attribute.Type == ConfigType.ConnectionString)
                        prop.SetValue(null, ConfigurationManager.ConnectionStrings[attribute.Key].ConnectionString);
                    else
                        prop.SetValue(null, ConfigurationManager.AppSettings[attribute.Key]);
                }
            }
        }
    }

    public enum ConfigType
    {
        AppSetting = 0,
        ConnectionString = 1
    }
}
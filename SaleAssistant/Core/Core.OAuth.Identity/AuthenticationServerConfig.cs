using Core.Common.Attributes;

namespace Core.OAuth.Identity
{
    public class AuthenticationServerConfig
    {
        static AuthenticationServerConfig()
        {
            ConfigAttribute.ReadConfigForType(typeof(AuthenticationServerConfig));
        }

        [Config("UserDbConnection", ConfigType.ConnectionString)]
        public static string ConnectionString { get; set; }

        [Config("as:Issuer")]
        public static string Issuer { get; set; }

        [Config("as:TokenEndpointPath")]
        public static string TokenEndpointPath { get; set; }

        [Config("as:AudienceId")]
        public static string AudienceId { get; set; }

        [Config("as:AudienceSecret")]
        public static string AudienceSecret { get; set; }

        [Config("as:AccessControlAllowOrigin")]
        public static string AccessControlAllowOrigin { get; set; }
    }
}
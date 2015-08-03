using System;
using System.Security.Cryptography;
using Core.OAuth.Identity.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace Core.OAuth.Identity
{
    public static class OAuthTokenExtensions
    {
        public static void ConfigureOAuthTokenGeneration(this IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString(AuthenticationServerConfig.TokenEndpointPath),
                AccessTokenExpireTimeSpan = TimeSpan.FromSeconds(25),
                Provider = new CustomOAuthProvider(),
                RefreshTokenProvider = new RefreshTokenProvider(),
                AccessTokenFormat = new CustomJwtFormat(AuthenticationServerConfig.Issuer)
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
        }

        public static void ConfigureOAuthTokenConsumption(this IAppBuilder app)
        {
            string issuer = AuthenticationServerConfig.Issuer;
            string audienceId = AuthenticationServerConfig.AudienceId;
            byte[] audienceSecret = TextEncodings.Base64Url.Decode(AuthenticationServerConfig.AudienceSecret);

            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audienceId },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
                    }
                });
        }

        public static string GetHashSHA256(this string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();
       
            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);

            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }
    }
}
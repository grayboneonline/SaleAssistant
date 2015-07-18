using System;
using Core.OAuth.Identity.Infrastucture;
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
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(UserIdentityDbContext.Create);
            app.CreatePerOwinContext<UserIdentityManager>(UserIdentityManager.Create);

            OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString(AuthenticationServerConfig.TokenEndpointPath),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new CustomOAuthProvider(),
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
    }
}
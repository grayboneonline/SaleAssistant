using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.OAuth.Identity.Infrastucture;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Core.OAuth.Identity
{
    public class AuthRepository : IDisposable
    {
        private readonly UserIdentityDbContext dbContext;
        private readonly UserIdentityManager userManager;

        public AuthRepository()
        {
            dbContext = new UserIdentityDbContext();
            userManager = new UserIdentityManager(new UserStore<UserIdentity>(dbContext));
        }

        public async Task<UserIdentity> FindUser(string userName, string password)
        {
            UserIdentity user = await userManager.FindAsync(userName, password);

            return user;
        }

        public async Task<ClaimsIdentity> GenerateClaims(UserIdentity user, string authenticationType)
        {
            var userIdentity = await userManager.CreateIdentityAsync(user, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public AppClient FindClient(string clientId)
        {
            var client = dbContext.Clients.Find(clientId);

            return client;
        }

        public async Task<bool> AddRefreshToken(RefreshToken token)
        {

            var existingToken = dbContext.RefreshTokens.SingleOrDefault(r => r.Subject == token.Subject && r.ClientId == token.ClientId);

            if (existingToken != null)
                await RemoveRefreshToken(existingToken);

            dbContext.RefreshTokens.Add(token);

            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = await dbContext.RefreshTokens.FindAsync(refreshTokenId);

            if (refreshToken != null)
            {
                dbContext.RefreshTokens.Remove(refreshToken);
                return await dbContext.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
        {
            dbContext.RefreshTokens.Remove(refreshToken);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await dbContext.RefreshTokens.FindAsync(refreshTokenId);

            return refreshToken;
        }

        public List<RefreshToken> GetAllRefreshTokens()
        {
            return dbContext.RefreshTokens.ToList();
        }

        public void Dispose()
        {
            dbContext.Dispose();
            userManager.Dispose();
        }
    }
}

using CleanDDD.Domain.Companies;
using CleanDDD.Infrastructure.Persistence.BaseDb.Models;
using CleanDDD.Domain.Users;
using CleanDDD.Infrastructure.Persistence.BaseDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDDD.Infrastructure.Persistence.Configuration.Domain.Users
{
    public class UserRepository : IUserRepository
    {
        public readonly BaseDbContext _baseDbContext;
        public UserRepository(BaseDbContext baseDbContext)
        {
            _baseDbContext = baseDbContext;
        }
        public async Task CreateUserAsync(User user)
        {
            var entity = new UserInfo
            {
                Name = user.Name,
                PasswordHash = user.PasswordHash,
                Type = user.Type,
                Nickname = user.Nickname,
                Email = user.Email,
                RefreshToken = user.RefreshToken,
                RefreshTokenExpires = user.RefreshTokenExpires,
                State = user.State,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _baseDbContext.UserInfo.AddAsync(entity);
            await _baseDbContext.SaveChangesAsync();
        }
    }
}

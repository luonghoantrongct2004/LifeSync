using LifeSync.Application.Auth.Interfaces;
using LifeSync.Domain.Users;
using LifeSync.Infrastructure.Common;
using LifeSync.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LifeSync.Infrastructure.Users;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _dbSet
            .FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbSet
            .FirstOrDefaultAsync(u => u.Email == email);
    }
} 
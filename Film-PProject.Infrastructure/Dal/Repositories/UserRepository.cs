using Film_PProject.Infrastructure.Dal.EntityFramework;
using Films_PProject.Application.Interfaces.Repositories;
using Films_PProject.Domain.Entities;
using Films_PProject.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Film_PProject.Infrastructure.Dal.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly DataContext _db;
    public UserRepository(DataContext db) : base(db)
    {
        _db = db;
    }

    public async Task<bool> IsExistAsync(string email, CancellationToken cancellationToken)
    {
        return await _db.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<bool> UpdateRole(Guid userId,RoleType Role, CancellationToken cancellationToken)
    {
        var user = await _db.Users.FindAsync(userId);
        
        if (user is null) 
            throw new KeyNotFoundException("User not found");
        
        user.Role = Role;
        
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _db.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }
}
using Film_PProject.Infrastructure.Dal.EntityFramework;
using Films_PProject.Application.Interfaces.Repositories;
using Films_PProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Film_PProject.Infrastructure.Dal.Repositories;

public class UserActorRepository : BaseRepository<UserActors>, IUserActorRepository
{
    private readonly DataContext _db;
    public UserActorRepository(DataContext db) : base(db)
    {
        _db = db;
    }

    public async Task<bool> AddFavoriteActorAsync(UserActors userActor, CancellationToken cancellationToken)
    {
        var existFavorits =await _db.UserActors
            .FirstOrDefaultAsync(x=>x.ActorId==userActor.ActorId&& x.UserId == userActor.UserId);
        if (existFavorits is not null)
            throw new Exception("Actor already favorited.");
        
        var movie = await _db.Actors.FindAsync(userActor.ActorId, cancellationToken);
        if (movie is null)
            throw new KeyNotFoundException("Actor not found");
        
        await _db.UserActors.AddAsync(userActor, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<UserActors>> GetAllUserActorAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _db.UserActors
            .Where(x => x.UserId == userId)
            .Include(x => x.Actor) 
            .ToListAsync(cancellationToken);
    }
    
    public async Task DeleteFavoriteActorAsync(UserActors userActor, CancellationToken cancellationToken)
    {
        _db.UserActors.Remove(userActor);
        await _db.SaveChangesAsync(cancellationToken);
    }
}
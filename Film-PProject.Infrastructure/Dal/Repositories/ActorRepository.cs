using Film_PProject.Infrastructure.Dal.EntityFramework;
using Films_PProject.Application.Interfaces.Repositories;
using Films_PProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Film_PProject.Infrastructure.Dal.Repositories;

public class ActorRepository : BaseRepository<Actor>, IActorRepository
{
    private readonly DataContext _db;
    public ActorRepository(DataContext db) : base(db)
    {
        _db = db;
    }

    public async Task<Actor> GetByIdAsync(Guid id,CancellationToken cancellationToken)
    {
        return await _db.Actors
            .Include(x=>x.MovieActors)
            .ThenInclude(x=>x.Movie)
            .Include(x=>x.AwardsCollection)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> AwardActorAsync(Guid awardId, Guid winnerId, CancellationToken cancellationToken)
    {
        var actor = await _db.Actors.FirstOrDefaultAsync(x => x.Id == winnerId, cancellationToken);
        if(actor is null)
            throw new KeyNotFoundException("Actor not found");
        var Award = await _db.Awards.FirstOrDefaultAsync(x => x.Id == awardId, cancellationToken);
        if(Award is null)
            throw new KeyNotFoundException("Actor not found");
        
        if (actor.AwardsCollection == null)
            actor.AwardsCollection = new List<Award>();
        
        actor.AwardsCollection?.Add(Award);
       
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }

   
}

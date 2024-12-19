using Film_PProject.Infrastructure.Dal.EntityFramework;
using Films_PProject.Application.Interfaces.Repositories;
using Films_PProject.Domain.Entities;

namespace Film_PProject.Infrastructure.Dal.Repositories;

public class MovieActorRepository : BaseRepository<MovieActor>, IMovieActorRepository
{
    private readonly DataContext _db;

    public MovieActorRepository(DataContext db) : base(db)
    {
        _db = db;
    }
    
    public async Task<bool> DeleteActorFromMovieAsync(MovieActor movieActor,CancellationToken cancellationToken)
    {
        var actor = await _db.MovieActors.FindAsync(movieActor.ActorId,cancellationToken);
        if(actor is null)
            throw new KeyNotFoundException($"Actor with Id: {movieActor.ActorId} does not exist.");
        
        var movie = await _db.MovieActors.FindAsync(movieActor.MovieId,cancellationToken);
        if (movie is null)
         throw new KeyNotFoundException($"Movie with Id: {movieActor.MovieId} does not exist.");
        
        _db.MovieActors.Remove(movieActor);
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
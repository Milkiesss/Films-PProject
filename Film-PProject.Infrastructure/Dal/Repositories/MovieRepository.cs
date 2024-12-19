using Film_PProject.Infrastructure.Dal.EntityFramework;
using Films_PProject.Application.Interfaces.Repositories;
using Films_PProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Film_PProject.Infrastructure.Dal.Repositories;

public class MovieRepository : BaseRepository<Movie>, IMovieRepository
{
    private readonly DataContext _db;
    public MovieRepository(DataContext db) : base(db)
    {
        _db = db;
    }
    public async Task<Movie> GetByIdAsync(Guid id,CancellationToken cancellationToken)
    {
        return await _db.Movies
            .Include(x=>x.MovieActors)
            .ThenInclude(x=>x.Actor)
            .Include(x=>x.AwardsCollection)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<bool> AwardMovieAsync(Guid awardId, Guid winnerId, CancellationToken cancellationToken)
    {
        var movie = await _db.Movies.FirstOrDefaultAsync(x => x.Id == winnerId, cancellationToken);
        if(movie is null)
            throw new KeyNotFoundException("Movies not found");
        var award = await _db.Awards.FirstOrDefaultAsync(x => x.Id == awardId, cancellationToken);
        if(award is null)
            throw new KeyNotFoundException("Award not found");
        if (movie.AwardsCollection == null)
            movie.AwardsCollection = new List<Award>();
        
        movie.AwardsCollection.Add(award);
       
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
using Film_PProject.Infrastructure.Dal.EntityFramework;
using Films_PProject.Application.Interfaces.Repositories;
using Films_PProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Film_PProject.Infrastructure.Dal.Repositories;

public class UserMovieRepository : BaseRepository<UserMovies>, IUserMovieRepository
{
    private readonly DataContext _db;
    public UserMovieRepository(DataContext db) : base(db)
    {
        _db = db;
    }

    public async Task<bool> AddFavoriteMovieAsync(UserMovies userMovie, CancellationToken cancellationToken)
    {
        var existFavorits =await _db.UserMovies
            .FirstOrDefaultAsync(x=>x.MovieId==userMovie.MovieId&& x.UserId == userMovie.UserId);
        if (existFavorits is not null)
            throw new Exception("Movie already favorited.");
        
        var movie = await _db.Movies.FindAsync(userMovie.MovieId, cancellationToken);
        if (movie is null)
            throw new KeyNotFoundException("Movie not found");
        
        await _db.UserMovies.AddAsync(userMovie, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
    public async Task<List<UserMovies>> GetAllUserMoviesAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _db.UserMovies
            .Where(x => x.UserId == userId)
            .Include(x => x.Movie)
            .ToListAsync(cancellationToken);
    }
    public async Task DeleteFavoriteMovieAsync(UserMovies userMovie, CancellationToken cancellationToken)
    {
        _db.UserMovies.Remove(userMovie);
        await _db.SaveChangesAsync(cancellationToken);
    }
}
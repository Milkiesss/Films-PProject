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

    public async Task<bool> AddFavoriteMovie(UserMovies userMovie, CancellationToken cancellationToken)
    {
        var existFavorits = _db.UserMovies
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

    public async Task DeleteFavoriteMovie(UserMovies userMovie, CancellationToken cancellationToken)
    {
        _db.UserMovies.Remove(userMovie);
        await _db.SaveChangesAsync(cancellationToken);
    }
}
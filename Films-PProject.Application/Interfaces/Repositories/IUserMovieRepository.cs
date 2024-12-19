using Films_PProject.Domain.Entities;

namespace Films_PProject.Application.Interfaces.Repositories;

public interface IUserMovieRepository 
{
    Task<bool> AddFavoriteMovieAsync(UserMovies userMovie,CancellationToken cancellationToken);
    public Task<List<UserMovies>> GetAllUserMoviesAsync(Guid userId, CancellationToken cancellationToken);
    Task DeleteFavoriteMovieAsync(UserMovies userMovie,CancellationToken cancellationToken);
}
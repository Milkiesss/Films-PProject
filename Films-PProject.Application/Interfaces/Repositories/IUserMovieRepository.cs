using Films_PProject.Domain.Entities;

namespace Films_PProject.Application.Interfaces.Repositories;

public interface IUserMovieRepository
{
    Task<bool> AddFavoriteMovie(UserMovies userMovie,CancellationToken cancellationToken);
    Task DeleteFavoriteMovie(UserMovies userMovie,CancellationToken cancellationToken);
}
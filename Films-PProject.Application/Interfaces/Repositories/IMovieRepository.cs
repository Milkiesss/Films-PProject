using Films_PProject.Domain.Entities;

namespace Films_PProject.Application.Interfaces.Repositories;

public interface IMovieRepository : IBaseRepository<Movie>
{
    public Task<Movie> GetByIdAsync(Guid id,CancellationToken cancellationToken);
    public Task<bool> AwardMovieAsync(Guid awardId, Guid winnerId, CancellationToken cancellationToken);
}
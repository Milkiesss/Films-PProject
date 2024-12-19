using Films_PProject.Domain.Entities;

namespace Films_PProject.Application.Interfaces.Repositories;

public interface IMovieActorRepository : IBaseRepository<MovieActor>
{
    Task<bool> DeleteActorFromMovieAsync(MovieActor movieActor, CancellationToken cancellationToken);
}
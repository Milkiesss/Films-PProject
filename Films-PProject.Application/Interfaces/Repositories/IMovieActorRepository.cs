using Films_PProject.Domain.Entities;

namespace Films_PProject.Application.Interfaces.Repositories;

public interface IMovieActorRepository
{
    Task DeleteActorFromMovieAsync(MovieActor movieActor, CancellationToken cancellationToken);
}
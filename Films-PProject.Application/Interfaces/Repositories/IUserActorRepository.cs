using Films_PProject.Domain.Entities;

namespace Films_PProject.Application.Interfaces.Repositories;

public interface IUserActorRepository
{
    Task<bool> AddFavoriteActor(UserActors userActor,CancellationToken cancellationToken);
    Task DeleteFavoriteActor(UserActors userActor,CancellationToken cancellationToken);
}
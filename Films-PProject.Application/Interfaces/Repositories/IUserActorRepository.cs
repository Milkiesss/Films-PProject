using Films_PProject.Domain.Entities;

namespace Films_PProject.Application.Interfaces.Repositories;

public interface IUserActorRepository
{
    Task<bool> AddFavoriteActorAsync(UserActors userActor,CancellationToken cancellationToken);
    public Task<List<UserActors>> GetAllUserActorAsync(Guid userId, CancellationToken cancellationToken);
    Task DeleteFavoriteActorAsync(UserActors userActor,CancellationToken cancellationToken);
}
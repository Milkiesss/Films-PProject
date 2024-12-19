using Films_PProject.Domain.Entities;

namespace Films_PProject.Application.Interfaces.Repositories;

public interface IActorRepository : IBaseRepository<Actor>
{
    public Task<Actor> GetByIdAsync(Guid id,CancellationToken cancellationToken);
    public Task<bool> AwardActorAsync(Guid awardId, Guid winnerId, CancellationToken cancellationToken);
}
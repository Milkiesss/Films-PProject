using Films_PProject.Domain.Entities;
using Films_PProject.Domain.Enums;

namespace Films_PProject.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<bool> IsExistAsync(string email,CancellationToken cancellationToken);
    Task UpdateRole(Guid userId,int Role, CancellationToken cancellationToken);
    Task<User> GetByEmail(string email,CancellationToken cancellationToken);
}
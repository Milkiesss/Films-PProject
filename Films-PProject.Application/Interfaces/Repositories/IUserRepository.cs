using Films_PProject.Domain.Entities;
using Films_PProject.Domain.Enums;

namespace Films_PProject.Application.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<bool> IsExistAsync(string email,CancellationToken cancellationToken);
    Task<bool> UpdateRole(Guid userId,RoleType Role, CancellationToken cancellationToken);
    Task<User> GetByEmailAsync(string email,CancellationToken cancellationToken);
}
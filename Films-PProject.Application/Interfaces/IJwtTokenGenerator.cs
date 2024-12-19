using Films_PProject.Domain.Entities;

namespace Films_PProject.Application.Interfaces;

public interface IJwtTokenGenerator
{
    public string GenerateToken(User entity);
}
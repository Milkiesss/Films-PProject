using Films_PProject.Domain.Enums;

namespace Films_PProject.Domain.Entities;

public class User
{
    public string FullName { get; set;}
    public string Email { get; set; }
    public string Password { get; set; }
    public RoleType Role { get; set; } = RoleType.User;
    public ICollection<UserActors> Actors { get; set; }
    public ICollection<UserMovies> Movies { get; set; }
}
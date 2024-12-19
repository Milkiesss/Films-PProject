using Films_PProject.Domain.Enums;
using Films_PProject.Domain.ValueObject;

namespace Films_PProject.Domain.Entities;

public class User : BaseEntity
{
    public User(Guid Id, string email, string password, FullName fullName)
    {
        SetId(Id);
        Email = email;
        Password = password;
        FullName = fullName;
    }

    public User()
    {
    }

    public FullName FullName { get; set;}
    public string Email { get; set; }
    public string Password { get; set; }
    public RoleType Role { get; set; } = RoleType.User;
    public ICollection<UserActors> Actors { get; set; }
    public ICollection<UserMovies> Movies { get; set; }
}
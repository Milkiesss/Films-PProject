namespace Films_PProject.Domain.Entities;

public class UserActors
{
    public Guid ActorId { get; set; }
    public Guid UserId { get; set; }
    public Actor Actor { get; set; } 
    public User User { get; set; }
}
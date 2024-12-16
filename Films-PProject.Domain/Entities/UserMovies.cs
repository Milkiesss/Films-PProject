namespace Films_PProject.Domain.Entities;

public class UserMovies
{
    public Guid MovieId { get; set; }
    public Guid UserId { get; set; }
    public Movie Movie { get; set; } 
    public User User { get; set; }
}
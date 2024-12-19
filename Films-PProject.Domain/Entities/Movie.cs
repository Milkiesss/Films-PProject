namespace Films_PProject.Domain.Entities;

public class Movie : BaseEntity
{
    public Movie(Guid Id, string name, DateTime releaseDate, string? trailerUrl, string directors, ICollection<string> genres)
    {
        SetId(Id);
        Name = name;
        ReleaseDate = releaseDate;
        TrailerUrl = trailerUrl;
        Directors = directors;
        Genres = genres;
    }

    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Description { get; set; }
    public string? TrailerUrl { get; set; }
    public string Directors { get; set; }
    
    public ICollection<string> Genres { get; set;}
    public ICollection<Award>? AwardsCollection { get; set; }
    
    public ICollection<MovieActor>? MovieActors { get; set; }
    
    
}
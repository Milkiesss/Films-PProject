namespace Films_PProject.Application.Dtos.MovieDto;

public class BaseMovieDto
{
    public string Name { get; init; }
    public DateTime ReleaseDate { get; init; }
    public string Description { get; init; }
    public string? TrailerUrl { get; init; }
    public string Directors { get; init; }
    public ICollection<string> Genres { get; init;}
}
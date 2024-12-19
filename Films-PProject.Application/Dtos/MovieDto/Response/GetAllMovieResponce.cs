namespace Films_PProject.Application.Dtos.MovieDto.Response;

public class GetAllMovieResponce
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Description { get; set; }
    public string? TrailerUrl { get; set; }
    public string Directors { get; set; }
    public ICollection<string> Genres { get; set;}
}
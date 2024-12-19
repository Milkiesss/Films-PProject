using Films_PProject.Application.Dtos.AwardDto;
using Films_PProject.Application.Dtos.AwardDto.Response;
using Films_PProject.Application.Dtos.MovieActorDto;

namespace Films_PProject.Application.Dtos.MovieDto.Response;

public class GetByIdMovieResponce
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Description { get; set; }
    public string? TrailerUrl { get; set; }
    public string Directors { get; set; }
    public ICollection<string> Genres { get; set;}
    public ICollection<GetAllAwardResponse>? AwardsCollection { get; set; }
    
    public ICollection<BaseMovieActorDto>? MovieActors { get; set; }
}
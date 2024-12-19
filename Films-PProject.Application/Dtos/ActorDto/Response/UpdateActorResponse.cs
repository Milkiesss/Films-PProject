using Films_PProject.Application.Dtos.AwardDto;
using Films_PProject.Application.Dtos.MovieDto;
using Films_PProject.Application.Dtos.MovieDto.MovieActor;

namespace Films_PProject.Application.Dtos.ActorDto.Response;

public class UpdateActorResponse : BaseActorDto
{
    public Guid Id { get; set; }
    public int Age => DateTime.Now.Year - BirthDay.Year;
    public ICollection<BaseAwardDto>? AwardsCollection { get; set; }
    public ICollection<BaseMovieActorDto>? MovieActors { get; set; }
}
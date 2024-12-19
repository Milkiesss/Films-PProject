using Films_PProject.Application.Dtos.AwardDto;
using Films_PProject.Application.Dtos.AwardDto.Response;
using Films_PProject.Application.Dtos.MovieActorDto;
using Films_PProject.Application.Dtos.MovieActorDto.Request;
using Films_PProject.Application.Dtos.MovieDto;
using Films_PProject.Application.Dtos.MovieDto.MovieActor;
using BaseMovieActorDto = Films_PProject.Application.Dtos.MovieActorDto.BaseMovieActorDto;

namespace Films_PProject.Application.Dtos.ActorDto.Response;

public class GetByIdActorResponse : BaseActorDto
{
    public Guid Id { get; set; }
    public int Age { get; set; }
    public ICollection<GetAllAwardResponse> AwardsCollection { get; set; }
    public ICollection<BaseMovieActorDto> MovieActors { get; set; }
}
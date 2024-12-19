namespace Films_PProject.Application.Dtos.MovieDto.Request;

public class UpdateMovieRequest : BaseMovieDto
{
    public Guid Id { get; init; }
}
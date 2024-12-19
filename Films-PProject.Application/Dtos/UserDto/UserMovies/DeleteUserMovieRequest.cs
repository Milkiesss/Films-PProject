using System.Text.Json.Serialization;

namespace Films_PProject.Application.Dtos.UserDto.UserMovies;

public class DeleteUserMovieRequest
{
    [JsonIgnore]
    public Guid UserId { get; set; }
    public Guid MovieID { get; set; }
}
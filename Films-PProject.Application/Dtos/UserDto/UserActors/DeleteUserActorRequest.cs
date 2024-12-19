using System.Text.Json.Serialization;

namespace Films_PProject.Application.Dtos.UserDto.UserActors;

public class DeleteUserActorRequest
{
    [JsonIgnore]
    public Guid UserId { get; set; }
    public Guid ActorId { get; set; }
}
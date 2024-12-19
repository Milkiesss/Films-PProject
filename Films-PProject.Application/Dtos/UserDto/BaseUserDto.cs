using Films_PProject.Application.Dtos.ActorDto;

namespace Films_PProject.Application.Dtos.UserDto;

public class BaseUserDto
{
    public FullNameDto FullName { get; set;}
    public string Email { get; set; }
    public string Password { get; set; }
}
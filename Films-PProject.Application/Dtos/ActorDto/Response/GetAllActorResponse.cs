namespace Films_PProject.Application.Dtos.ActorDto.Response;

public class GetAllActorResponse : BaseActorDto
{
    public Guid Id { get; set; }
    public int Age => DateTime.Now.Year - BirthDay.Year;
}
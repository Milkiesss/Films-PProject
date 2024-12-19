using Films_PProject.Domain.Enums;

namespace Films_PProject.Application.Dtos.AwardDto;

public class BaseAwardDto
{
    public string Name { get; set; }
    public AwardStatus AwardStatus { get;set;}
    public string Reason { get; set; }
}
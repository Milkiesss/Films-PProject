using Films_PProject.Domain.Enums;

namespace Films_PProject.Domain.Entities;

public class Award : BaseEntity
{
    public string Name { get; set; }
    public AwardStatus AwardStatus { get; set; }
    public string Reason { get; set; }
}
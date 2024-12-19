using Films_PProject.Domain.Enums;

namespace Films_PProject.Domain.Entities;

public class Award : BaseEntity
{
    public Award(Guid Id, string name, AwardStatus awardStatus, string reason)
    {
        SetId(Id);
        Name = name;
        AwardStatus = awardStatus;
        Reason = reason;
    }

    public string Name { get; set; }
    public AwardStatus AwardStatus { get; set; }
    public string Reason { get; set; }
}
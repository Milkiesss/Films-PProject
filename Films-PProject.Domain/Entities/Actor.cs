using Films_PProject.Domain.ValueObject;

namespace Films_PProject.Domain.Entities;

public class Actor : BaseEntity
{
    public Actor(Guid Id, FullName fullName, DateTime birthDay, string placeOfBirth)
    {
        SetId(Id);
        FullName = fullName;
        BirthDay = birthDay;
        PlaceOfBirth = placeOfBirth;
    }
    public Actor()
    {}
    
    public FullName FullName { get; set; }
    public DateTime BirthDay { get; set; }
    public int Age => DateTime.Now.Year - BirthDay.Year;
    public string PlaceOfBirth { get; set; }
    public ICollection<Award>? AwardsCollection { get; set; }
    public ICollection<MovieActor>? MovieActors { get; set; }
}
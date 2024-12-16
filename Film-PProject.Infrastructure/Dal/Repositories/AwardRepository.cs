using Film_PProject.Infrastructure.Dal.EntityFramework;
using Films_PProject.Application.Interfaces.Repositories;
using Films_PProject.Domain.Entities;

namespace Film_PProject.Infrastructure.Dal.Repositories;

public class AwardRepository : BaseRepository<Award>, IAwardRepository
{
    public AwardRepository(DataContext db) : base(db)
    {
    }
}
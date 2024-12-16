using Film_PProject.Infrastructure.Dal.EntityFramework;
using Films_PProject.Application.Interfaces.Repositories;
using Films_PProject.Domain.Entities;


namespace Film_PProject.Infrastructure.Dal.Repositories;

public class ActorRepository : BaseRepository<Actor>, IActorRepository
{
    public ActorRepository(DataContext db) : base(db)
    {
    }
    
}
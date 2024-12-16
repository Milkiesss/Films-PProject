using Film_PProject.Infrastructure.Dal.EntityFramework;
using Films_PProject.Application.Interfaces.Repositories;
using Films_PProject.Domain.Entities;

namespace Film_PProject.Infrastructure.Dal.Repositories;

public class MovieRepository : BaseRepository<Movie>, IMovieRepository
{
    public MovieRepository(DataContext db) : base(db)
    {
    }
}
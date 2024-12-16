using Films_PProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Film_PProject.Infrastructure.Dal.EntityFramework;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Award> Awards { get; set; }
    public DbSet<Movie> Movies { get; set; }
    
    public DbSet<UserMovies> UserMovies { get; set; }
    public DbSet<UserActors> UserActors { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<MovieActor> MovieActors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
    
}
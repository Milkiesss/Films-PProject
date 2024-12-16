using Film_PProject.Infrastructure.Dal.EntityFramework;
using Films_PProject.Application.Interfaces.Repositories;
using Films_PProject.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Film_PProject.Infrastructure.Dal.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly DataContext _db;

    protected BaseRepository(DataContext db)
    {
        _db = db;
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _db.Set<T>().AddAsync(entity,cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
    { 
        _db.Set<T>().Update(entity);
        await _db.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task DeleteAsync(Guid Id, CancellationToken cancellationToken)
    {
        var entity = await _db.Set<T>().FindAsync(Id,cancellationToken);
        if(entity is null)
            throw new KeyNotFoundException("Entity not found");
        _db.Set<T>().Remove(entity);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        return await _db.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == Id,cancellationToken);
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
       await _db.SaveChangesAsync();
    }
}
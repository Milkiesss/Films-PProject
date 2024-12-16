namespace Films_PProject.Application.Interfaces.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<T> AddAsync(T entity,CancellationToken cancellationToken);
    Task<T> UpdateAsync(T entity,CancellationToken cancellationToken);
    Task DeleteAsync(Guid Id,CancellationToken cancellationToken);
    Task<T?> GetByIdAsync(Guid Id,CancellationToken cancellationToken);
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
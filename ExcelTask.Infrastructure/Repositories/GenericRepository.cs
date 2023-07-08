using ExcelTask.Application.IRepositories;
using ExcelTask.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ExcelTask.Infrastructure.Repositories;

public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class
{
    protected ExcelTaskDbContext _context;
    protected DbSet<TEntity> _dbSet;

    public GenericRepository(ExcelTaskDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllEntitiesAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<TEntity> GetEntityByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task AddEntityAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public virtual Task UpdateEntity(TEntity entity)
    {
        _dbSet.Update(entity);
        return Task.CompletedTask;
    }

    public virtual async Task DeleteEntityByIdAsync(int id)
    {
        var entity = await GetEntityByIdAsync(id);
        _dbSet.Remove(entity);
    }
}

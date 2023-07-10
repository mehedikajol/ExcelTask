namespace ExcelTask.Application.IRepositories;

public interface IGenericRepository<TEntity>
    where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllEntitiesAsync();
    Task<TEntity> GetEntityByIdAsync(int id);

    Task AddEntityAsync(TEntity entity);
    Task UpdateEntity(TEntity entity);
    Task DeleteEntityByIdAsync(int id);
}

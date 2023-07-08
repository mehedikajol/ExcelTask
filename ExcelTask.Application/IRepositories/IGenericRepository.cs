namespace ExcelTask.Application.IRepositories;

public interface IGenericRepository<TEntity>
    where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllEntities();
    Task<TEntity> GetEntityById(Guid id);

    Task<bool> AddEntity(TEntity entity);
    Task<bool> UpdateEntity(TEntity entity);
    Task<bool> DeleteEntityById(Guid id);
}

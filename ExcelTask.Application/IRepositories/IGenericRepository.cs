namespace ExcelTask.Application.IRepositories;

public interface IGenericRepository<TEntity>
    where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllEntities();
    Task<TEntity> GetEntityById(int id);

    Task AddEntity(TEntity entity);
    Task UpdateEntity(TEntity entity);
    Task DeleteEntityById(int id);
}

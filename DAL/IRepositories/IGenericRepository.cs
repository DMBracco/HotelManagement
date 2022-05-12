namespace HotelManagement.DAL.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetListAsync();

        Task<TEntity?> GetByIdOrNullAsync(object id);

        Task UpdateAsync(TEntity entityToUpdate);

        Task CreateAsync(TEntity entity);

        Task<bool> DeleteAsync(object id);

        Task SaveAsync();
    }
}

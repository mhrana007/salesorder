namespace DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int Id);
        public Task DeleteAsync(int id);
    }
}

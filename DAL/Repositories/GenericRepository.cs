using DAL.DataContext;
using DAL.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //
        protected readonly DatabaseContext _context;
        public GenericRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                var obj = await _context.Set<T>().AddAsync(entity);
                _context.SaveChanges();
                return obj.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
            //try
            //{
            //    var data = _context.Set<T>().FirstOrDefault(x => x.Id == id);
            //    _context.Remove(data);
            //    await _context.SaveChangesAsync();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<T> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

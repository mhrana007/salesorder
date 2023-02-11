using DAL.DataContext;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class WindowRepository : IWindowRepository
    {
        protected readonly DatabaseContext _context;
        public WindowRepository(DatabaseContext context) //: base(context)
        {
            _context = context;
        }

        public async Task<TblWindows> CreateAsync(TblWindows entity)
        {
            var obj = await _context.TblWindows.AddAsync(entity);
            _context.SaveChanges();
            return obj.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var data = _context.TblWindows.FirstOrDefault(x => x.Id == id);
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TblWindows>> GetAllAsync()
        {
            return await _context.TblWindows.ToListAsync();
        }

        public async Task<TblWindows> GetByIdAsync(int Id)
        {
            return await _context.Set<TblWindows>().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task UpdateAsync(TblWindows entity)
        {
            _context.TblWindows.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

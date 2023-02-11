using DAL.DataContext;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class ElementRepository:IElementRepository
    {
        protected readonly DatabaseContext _context;
        public ElementRepository(DatabaseContext context) //: base(context)
        {
            _context = context;
        }

        public Task<TblSubElements> CreateAsync(TblSubElements entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TblSubElements>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TblSubElements> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TblSubElements entity)
        {
            throw new NotImplementedException();
        }
    }
}

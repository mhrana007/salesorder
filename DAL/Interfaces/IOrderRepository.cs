using DAL.Models;

namespace DAL.Interfaces
{
    public interface IOrderRepository : IGenericRepository<TblOrders>
    {
        public Task DeleteWindowAsync(int id);
        public Task DeleteElementAsync(int id);
    }
}

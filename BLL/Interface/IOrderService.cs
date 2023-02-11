using DAL.Models;

namespace BLL.Interface
{
    public interface IOrderService
    {
        Task<TblOrders> AddOrder(TblOrders order);
        Task<bool> UpdateOrder(int id, TblOrders order);
        Task<bool> DeleteOrder(int id);
        Task<bool> DeleteWindow(int id);
        Task<bool> DeleteElement(int id);
        Task<TblOrders> GetOrder(int id);
        Task<List<TblOrders>> GetAllOrder();
    }
}

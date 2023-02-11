using DAL.Models;

namespace BLL.Interface
{
    public interface IWindowService
    {
        Task<TblWindows> AddWindow(TblWindows window);
        Task<bool> UpdateWindow(int id, TblWindows window);
        Task<bool> DeleteWindow(int id);
        Task<TblWindows> GetWindow(int id);
    }
}

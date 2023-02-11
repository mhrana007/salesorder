using DAL.Models;

namespace BLL.Interface
{
    public interface IElementService
    {
        Task<TblSubElements> AddElement(TblSubElements element);
        Task<bool> UpdateElement(int id, TblSubElements element);
        Task<bool> DeleteElement(int id);
        Task<TblSubElements> GetElement(int id);
    }
}

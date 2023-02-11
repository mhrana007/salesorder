using BLL.Interface;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Services
{
    public class WindowService: IWindowService
    {
        private readonly IWindowRepository _repository;
        public WindowService(IWindowRepository repository)
        {
            _repository = repository;
        }

        public async Task<TblWindows> AddWindow(TblWindows window)
        {
            return await _repository.CreateAsync(window);
        }

        public Task<bool> DeleteWindow(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TblWindows> GetWindow(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateWindow(int id, TblWindows window)
        {
            throw new NotImplementedException();
        }
    }
}

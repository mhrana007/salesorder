using BLL.Interface;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<TblOrders> _repository;
        private readonly IOrderRepository _repositoryorder;
        public OrderService(IGenericRepository<TblOrders> repository, IOrderRepository repositoryorder)
        {
            _repository = repository;
            _repositoryorder = repositoryorder;
        }
        public async Task<TblOrders> AddOrder(TblOrders order)
        {
            try
            {
                return await _repositoryorder.CreateAsync(order);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteOrder(int id)
        {
            await _repositoryorder.DeleteAsync(id);
            return true;
        }
        public async Task<bool> DeleteWindow(int id)
        {
            await _repositoryorder.DeleteWindowAsync(id);
            return true;
        }
        public async Task<bool> DeleteElement(int id)
        {
            await _repositoryorder.DeleteElementAsync(id);
            return true;
        }

        public async Task<TblOrders> GetOrder(int id)
        {
            try
            {
                return await _repositoryorder.GetByIdAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<TblOrders>> GetAllOrder()
        {
            try
            {
                //List<BuildingModel> list = new List<BuildingModel>();
                var result = await _repository.GetAllAsync();
                //result.ForEach(item => { list.Add(new BuildingModel() { Id = item.Id, Location = item.Location, Name = item.Name }); });
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateOrder(int id, TblOrders order)
        {
            try
            {
                await _repositoryorder.UpdateAsync(order);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

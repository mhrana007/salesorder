using BLL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SalesOrder.Server.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }
        //[HttpPost]
        //public void Post(TblOrders item)
        //{
        //    _service.AddOrder(item);
        //}
        [HttpGet("getallorder")]
        public async Task<List<TblOrders>> GetAll()
        {
            return await _service.GetAllOrder();
        }
        [HttpGet("{id}")]
        public async Task<TblOrders> Get(int id)
        {
            return await _service.GetOrder(id);
        }
        [HttpPost("addorder")]
        public async Task<TblOrders> AddOrder([FromBody] TblOrders order)
        {
            return await _service.AddOrder(order);
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteOrder(int id)
        {
            await _service.DeleteOrder(id);
            return true;
        }
        [HttpDelete("deletewindow/{id}")]
        public async Task<bool> DeleteWindow(int id)
        {
            await _service.DeleteOrder(id);
            return true;
        }
        [HttpDelete("deleteelement/{id}")]
        public async Task<bool> DeleteElement(int id)
        {
            await _service.DeleteOrder(id);
            return true;
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateOrder(int id, [FromBody] TblOrders Object)
        {
            await _service.UpdateOrder(id, Object);
            return true;
        }
    }
}

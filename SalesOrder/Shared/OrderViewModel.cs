
namespace SalesOrder.Shared
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public string State { get; set; }
        public List<WindowViewModel> Windows { get; set; } = new List<WindowViewModel>();
    }
}

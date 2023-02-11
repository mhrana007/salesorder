
namespace SalesOrder.Shared
{
    public class WindowViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string WindowName { get; set; }
        public int Quantity { get; set; }
        public List<ElementViewModel> SubElements { get; set; } = new List<ElementViewModel>();
    }
}

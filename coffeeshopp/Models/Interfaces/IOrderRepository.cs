using coffeeshopp.Models;

namespace coffeeshopp.Models.Interfaces
{
    public interface IOrderRepository
    {
        void PlaceOrder(Order order);
    }
}
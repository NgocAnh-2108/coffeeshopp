using coffeeshopp.Data;
using coffeeshopp.Models;
using coffeeshopp.Models.Interfaces;

namespace coffeeshopp.Models.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CoffeeshopDbContext dbContext;

        private readonly IShoppingCartRepository shoppingCartRepository;

        public OrderRepository(
            CoffeeshopDbContext dbContext,
            IShoppingCartRepository shoppingCartRepository)
        {
            this.dbContext = dbContext;
            this.shoppingCartRepository = shoppingCartRepository;
        }


        public void PlaceOrder(Order order)
        {
            var shoppingCartItems =
                shoppingCartRepository.GetAllShoppingCartItems();

            order.OrderPlaced = DateTime.Now;

            order.OrderTotal =
                shoppingCartRepository.GetShoppingCartTotal();

            dbContext.Orders.Add(order);

            dbContext.SaveChanges();

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Quantity = item.Qty,
                    ProductId = item.Product.Id,
                    OrderId = order.Id,
                    Price = item.Product.Price
                };

                dbContext.OrderDetails.Add(orderDetail);
            }

            dbContext.SaveChanges();
        }
    }
}
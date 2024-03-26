using Contract;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class OrderQueryRepository(MainContext context) : IOrderQueryRepository
    {
        private readonly MainContext _context = context;

        public async Task<IList<OrderDto>> GetOrderDetailsAsync(int companyId)
        {

            var companyQuery = from c in _context.Company
                               join o in _context.Order 
                               on c.Company_id equals o.Order_id
                               select new { c.Name, o.Description, o.Order_id };

            var orders = new List<OrderDto>();

            foreach (var order in companyQuery)
            {
                orders.Add(new OrderDto
                {
                    CompanyName = order.Name,
                    Description = order.Description,
                    OrderId = order.Order_id,
                    OrderProducts = new List<OrderProductDto>()
                });
            }


            var orderProductsQuery = from op in _context.OrderProduct
                                     join p in _context.Product
                                     on op.Product_id equals p.Product_id
                                     select new { OrderPrice = op.Price, OrderId = op.Order_id, OrderProductId = op.Product_id, op.Quantity, p.Name, ProductPrice = p.Price }
                                     into result
                                     select result;


            var orderProducts = new List<OrderProductDto>();

            foreach (var orderProduct in orderProductsQuery)
            {
                orderProducts.Add(new OrderProductDto
                {
                    OrderId = orderProduct.OrderId,
                    Price = orderProduct.OrderPrice,
                    ProductId = (int)orderProduct.OrderProductId,
                    Quantity = orderProduct.Quantity,
                    Product = new ProductDto
                    {
                        Id = (int)orderProduct.OrderProductId,
                        Name = orderProduct.Name,
                        Price = orderProduct.ProductPrice
                    }
                });
            }

            foreach (var order in orders)
            {
               foreach (var orderProduct in orderProducts)
                {
                    if (order.OrderId != orderProduct.OrderId)
                        continue;

                    order.OrderProducts.Add(orderProduct);
                    order.OrderTotal += orderProduct.Price * orderProduct.Quantity;
                }
            }

            return await Task.FromResult(orders);
        }
    }
}

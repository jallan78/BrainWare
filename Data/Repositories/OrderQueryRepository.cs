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

           var query = from c in _context.Company
                join o in _context.Order on c.Company_id equals o.Order_id
                join op in _context.OrderProduct on o.Order_id equals op.Order_id
                join p in _context.Product on op.Product_id equals p.Product_id
                where c.Company_id == companyId
                select new OrderDto
                {
                    CompanyName = c.Name,
                    Description = o.Description,
                    OrderId = o.Order_id,
                    OrderProducts = new List<OrderProductDto>
                    {
                        new() {
                            OrderId = o.Order_id,
                            ProductId = p.Product_id,
                            Price = op.Price,
                            Quantity = op.Quantity,
                            Product = new ProductDto
                            {
                                Id = p.Product_id,
                                Name = p.Name,
                                Price = p.Price
                            }
                        }
                    }
                };

            return await query.ToListAsync();
        }
    }
}

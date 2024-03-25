﻿namespace Api.Infrastructure
{
    using System.Data;
    using System.Threading.Tasks;
    using Contract;
    using Domain.Repositories;
    using Models;

    public class OrderService(IOrderQueryRepository orderQueryRepository) : IOrderService
    {
        private readonly IOrderQueryRepository _orderQueryRepository = orderQueryRepository;

        public IList<Order> GetOrdersForCompany(int CompanyId)
        {
            var database = new Database();

            // Get the orders
            var sql1 =
                "SELECT c.name, o.description, o.order_id FROM company c INNER JOIN [order] o on c.company_id=o.company_id";

            var reader1 = database.ExecuteReader(sql1);

            var values = new List<Order>();
            
            while (reader1.Read())
            {
                var record1 = (IDataRecord) reader1;

                values.Add(new Order()
                {
                    CompanyName = record1.GetString(0),
                    Description = record1.GetString(1),
                    OrderId = record1.GetInt32(2),
                    OrderProducts = new List<OrderProduct>()
                });

            }

            reader1.Close();

            //Get the order products
            var sql2 =
                "SELECT op.price, op.order_id, op.product_id, op.quantity, p.name, p.price FROM orderproduct op INNER JOIN product p on op.product_id=p.product_id";

            var reader2 = database.ExecuteReader(sql2);

            var values2 = new List<OrderProduct>();

            while (reader2.Read())
            {
                var record2 = (IDataRecord)reader2;

                values2.Add(new OrderProduct()
                {
                    OrderId = record2.GetInt32(1),
                    ProductId = record2.GetInt32(2),
                    Price = record2.GetDecimal(0),
                    Quantity = record2.GetInt32(3),
                    Product = new Product()
                    {
                        Name = record2.GetString(4),
                        Price = record2.GetDecimal(5)
                    }
                });
             }

            reader2.Close();

            foreach (var order in values)
            {
                foreach (var orderproduct in values2)
                {
                    if (orderproduct.OrderId != order.OrderId)
                        continue;

                    order.OrderProducts.Add(orderproduct);
                    order.OrderTotal = order.OrderTotal + (orderproduct.Price * orderproduct.Quantity);
                }
            }

            return values;
        }

        public async Task<IList<OrderDto>> GetOrdersListAsync(int CompanyId)
        {
            try
            {
                return await _orderQueryRepository.GetOrderDetailsAsync(CompanyId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting orders", ex);
            }
        }
    }
}
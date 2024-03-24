using Api.Models;
using Contract;

namespace Api.Infrastructure
{
    public interface IOrderService
    {
        public IList<Order> GetOrdersForCompany(int CompanyId);

        public Task<IList<OrderDto>> GetOrdersListAsync(int CompanyId);
    }
}

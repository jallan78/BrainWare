using Api.Models;
using Contract;

namespace Api.Infrastructure
{
    public interface IOrderService
    {
        public Task<IList<OrderDto>> GetOrdersListAsync(int CompanyId);
    }
}

using Api.Models;

namespace Api.Infrastructure
{
    public interface IOrderService
    {
        public List<Order> GetOrdersForCompany(int CompanyId);
    }
}

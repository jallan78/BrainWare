namespace Api.Infrastructure
{
    using System.Data;
    using System.Threading.Tasks;
    using Contract;
    using Domain.Repositories;
    using Models;

    public class OrderService(IOrderQueryRepository orderQueryRepository) : IOrderService
    {
        private readonly IOrderQueryRepository _orderQueryRepository = orderQueryRepository;

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
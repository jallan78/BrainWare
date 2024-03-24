using Contract;

namespace Domain.Repositories
{
    public interface IOrderQueryRepository
    {
        Task<IList<OrderDto>> GetOrderDetailsAsync(int companyId);
    }
}

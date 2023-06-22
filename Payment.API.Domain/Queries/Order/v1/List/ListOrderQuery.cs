using Payment.API.Domain.Contracts.v1;

namespace Payment.API.Domain.Queries.Order.v1.List
{
    public class ListOrderQuery
    {
        private readonly IOrderRepository _orderRepository;

        public ListOrderQuery(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Entities.v1.Order>> List()
        {
            return await _orderRepository.GetAllAsync();
        }
    }
}

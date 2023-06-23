using AutoMapper;
using MediatR;
using Payment.API.Domain.Contracts.v1;

namespace Payment.API.Domain.Queries.Order.v1.List
{
    public class ListOrderQueryHandler : BaseHandler, IRequestHandler<ListOrderQuery, IEnumerable<ListOrderQueryResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public ListOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ListOrderQueryResponse>> Handle(ListOrderQuery query, CancellationToken cancellation)
        {
            var orders = await _orderRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ListOrderQueryResponse>>(orders);
        }
    }
}

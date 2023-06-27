using AutoMapper;
using MediatR;
using Payment.API.Domain.Contracts.v1;

namespace Payment.API.Domain.Queries.Order.v1.List
{
    public class ListOrderQueryHandler : BaseHandler, IRequestHandler<ListOrderQuery, IEnumerable<ListOrderQueryResponse>>
    {
        private readonly IBaseRepository<Entities.v1.Order> _orderRepository;
        private readonly IMapper _mapper;

        public ListOrderQueryHandler(IMapper mapper, IBaseRepository<Entities.v1.Order> orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;

        }

        public async Task<IEnumerable<ListOrderQueryResponse>> Handle(ListOrderQuery query, CancellationToken cancellation)
        {
            var orders = await _orderRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ListOrderQueryResponse>>(orders);
        }
    }
}

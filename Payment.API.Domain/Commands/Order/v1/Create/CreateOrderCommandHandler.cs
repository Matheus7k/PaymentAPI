using AutoMapper;
using Payment.API.Domain.Contracts.v1;
using Payment.API.Domain.Entities.v1;

namespace Payment.API.Domain.Commands.Order.v1.Create
{
    public class CreateOrderCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Entities.v1.Order> Insert(CreateOrderCommand command)
        {
            var entity = _mapper.Map<Entities.v1.Order>(command);

            await _orderRepository.InsertAsync(entity);

            return entity;
        }
    }
}

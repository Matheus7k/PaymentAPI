using AutoMapper;
using MediatR;
using Payment.API.Domain.Contracts.v1;

namespace Payment.API.Domain.Commands.Order.v1.Create
{
    public class CreateOrderCommandHandler : BaseHandler, IRequestHandler<CreateOrderCommand, Entities.v1.Order>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Entities.v1.Order> Handle(CreateOrderCommand command, CancellationToken cancellation)
        {
            var entity = _mapper.Map<Entities.v1.Order>(command);

            await _orderRepository.InsertAsync(entity);

            return entity;
        }
    }
}

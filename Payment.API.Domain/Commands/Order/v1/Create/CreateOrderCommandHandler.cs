using AutoMapper;
using MediatR;
using Payment.API.Domain.Contracts.v1;

namespace Payment.API.Domain.Commands.Order.v1.Create
{
    public class CreateOrderCommandHandler : BaseHandler, IRequestHandler<CreateOrderCommand, Entities.v1.Order>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Entities.v1.Order> _orderRepository;


        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IBaseRepository<Entities.v1.Order> orderRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderRepository = orderRepository;

        }

        public async Task<Entities.v1.Order> Handle(CreateOrderCommand command, CancellationToken cancellation)
        {
            var entity = _mapper.Map<Entities.v1.Order>(command);

            _orderRepository.InsertAsync(entity);
            _orderRepository.InsertAsync(entity);
            _orderRepository.InsertAsync(entity);
            _orderRepository.InsertAsync(entity);

            await _unitOfWork.Commit();

            return entity;
        }
    }
}

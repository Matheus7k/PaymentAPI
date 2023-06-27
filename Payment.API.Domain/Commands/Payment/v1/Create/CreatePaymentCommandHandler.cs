using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payment.API.Domain.Contexts.v1;
using Payment.API.Domain.Contracts.v1;

namespace Payment.API.Domain.Commands.Payment.v1.Create
{
    public class CreatePaymentCommandHandler : BaseHandler, IRequestHandler<CreatePaymentCommand, ActionResult<Entities.v1.Payment>>
    {
        private readonly IMapper _mapper;
        private readonly PaymentContext _context;
        private readonly IPaymentFactory _paymentFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Entities.v1.Payment> _paymentRepository;

        public CreatePaymentCommandHandler(IUnitOfWork unitOfWork, PaymentContext context, IPaymentFactory paymentFactory, IMapper mapper, IBaseRepository<Entities.v1.Payment> paymentRepository)
        {
            _mapper = mapper;
            _context = context;
            _paymentFactory = paymentFactory;
            _unitOfWork = unitOfWork;
            _paymentRepository = paymentRepository;
        }

        public async Task<ActionResult<Entities.v1.Payment>> Handle(CreatePaymentCommand command, CancellationToken cancellation)
        {
            try
            {
                var entity = _mapper.Map<Entities.v1.Payment>(command);

                var strategy = _paymentFactory.GetStrategy(entity.PaymentForm);

                entity.Price = _context.ExecutePayment(strategy, entity.Price);

                _paymentRepository.InsertAsync(entity);

                await _unitOfWork.Commit();

                return entity;
            }
            catch
            {
                return new BadRequestObjectResult("Metodo de pagamento não encontrado!");
            }
        }
    }
}

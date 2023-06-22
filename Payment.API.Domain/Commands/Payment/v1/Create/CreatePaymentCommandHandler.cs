using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Payment.API.Domain.Contexts.v1;
using Payment.API.Domain.Contracts.v1;

namespace Payment.API.Domain.Commands.Payment.v1.Create
{
    public class CreatePaymentCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly PaymentContext _context;
        private readonly IPaymentFactory _paymentFactory;
        private readonly IPaymentRepository _paymentRepository;

        public CreatePaymentCommandHandler(IPaymentRepository paymentRepository, PaymentContext context, IPaymentFactory paymentFactory, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _paymentFactory = paymentFactory;
            _paymentRepository = paymentRepository;
        }

        public async Task<ActionResult<Entities.v1.Payment>> Insert(CreatePaymentCommand command)
        {
            try
            {
                var entity = _mapper.Map<Entities.v1.Payment>(command);

                var strategy = _paymentFactory.GetStrategy(entity.PaymentForm);

                entity.Price = _context.ExecutePayment(strategy, entity.Price);

                await _paymentRepository.InsertAsync(entity);

                return entity;
            }
            catch
            {
                return new BadRequestObjectResult("Metodo de pagamento não encontrado!");
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Payment.API.Domain.Contexts.v1;
using Payment.API.Domain.Contracts.v1;
using Payment.API.Domain.Helpers.v1;

namespace Payment.API.Domain.Commands.Payment.v1
{
    public class PaymentCommandHandler
    {
        private readonly PaymentContext _context;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentCommandHandler(IPaymentRepository paymentRepository, PaymentContext context)
        {
            _context = context;
            _paymentRepository = paymentRepository;
        }

        public async Task<ActionResult<Entities.v1.Payment>> Insert(Entities.v1.Payment payment)
        {
            try
            {
                var strategy = payment.SelectStrategy();

                var price = _context.ExecutePayment((IStrategy)strategy, payment.Price);

                payment.Price = price;

                await _paymentRepository.InsertAsync(payment);

                return payment;
            }
            catch
            {
                return new BadRequestObjectResult("Metodo de pagamento não encontrado!");
            }            
        }
    }
}

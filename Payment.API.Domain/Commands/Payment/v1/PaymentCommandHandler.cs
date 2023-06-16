using Payment.API.Domain.Contexts.v1;
using Payment.API.Domain.Contracts.v1;
using Payment.API.Domain.Dictionaries;

namespace Payment.API.Domain.Commands.Payment.v1
{
    public class PaymentCommandHandler
    {
        private readonly PaymentContext _context;
        private readonly PaymentDictionary _paymentDictionary;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentCommandHandler(IPaymentRepository paymentRepository)
        {
            _context = new PaymentContext();
            _paymentDictionary = new PaymentDictionary();
            _paymentRepository = paymentRepository;
        }

        public async Task<Entities.v1.Payment> Insert(Entities.v1.Payment payment)
        {
            var calculatadePrice = _context.ExecutePayment(_paymentDictionary.GetPayment(payment.PaymentForm), payment.Price);

            payment.Price = calculatadePrice;

            await _paymentRepository.InsertAsync(payment);

            return payment;
        }
    }
}

using Payment.API.Domain.Contexts.v1;
using Payment.API.Domain.Contracts.v1;
using Payment.API.Domain.Dictionaries;
using Payment.API.Domain.Strategies.v1;

namespace Payment.API.Domain.Commands.Payment.v1
{
    public class PaymentCommandHandler
    {
        private readonly PaymentContext _context;
        private readonly PaymentDictionary _paymentDictionary;

        public PaymentCommandHandler()
        {
            _context = new PaymentContext();
            _paymentDictionary = new PaymentDictionary();
        }

        public async Task<Entities.v1.Payment> Handler(Entities.v1.Payment payment)
        {
            var calculatadePrice = _context.ExecutePayment(_paymentDictionary.GetPayment(payment.PaymentForm), payment.Price);

            payment.Price = calculatadePrice;

            return payment;
        }
    }
}

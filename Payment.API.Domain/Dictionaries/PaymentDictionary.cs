using Payment.API.Domain.Contracts.v1;
using Payment.API.Domain.Strategies.v1;

namespace Payment.API.Domain.Dictionaries
{
    public class PaymentDictionary
    {
        Dictionary<string, IStrategy> PaymentsTypes = new();

        public PaymentDictionary()
        {
            PaymentsTypes["CREDITO"] = new CreditCardStrategy();
            PaymentsTypes["DEBITO"] = new DebitCardStrategy();
            PaymentsTypes["PIX"] = new PixStrategy();
            PaymentsTypes["BOLETO"] = new TicketStrategy();
        }

        public IStrategy GetPayment(string payment)
        {
            return PaymentsTypes[payment.ToUpper()];
        }
    }
}

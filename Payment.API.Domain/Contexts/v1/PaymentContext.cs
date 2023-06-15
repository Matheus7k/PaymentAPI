using Payment.API.Domain.Contracts.v1;

namespace Payment.API.Domain.Contexts.v1
{
    public class PaymentContext
    {
        public double ExecutePayment(IStrategy strategy, double price)
        {
            return strategy.Pay(price);
        }
    }
}

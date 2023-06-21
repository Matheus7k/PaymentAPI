namespace Payment.API.Domain.Contracts.v1
{
    public interface IPaymentFactory
    {
        public IStrategy GetStrategy(string paymentForm);
    }
}

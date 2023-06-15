using Payment.API.Domain.Contracts.v1;

namespace Payment.API.Domain.Strategies.v1
{
    public class TicketStrategy : IStrategy
    {
        public double Pay(double price)
        {
            return price;
        }
    }
}

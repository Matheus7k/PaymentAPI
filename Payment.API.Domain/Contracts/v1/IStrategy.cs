namespace Payment.API.Domain.Contracts.v1
{
    public interface IStrategy
    {
        double Pay(double price);
    }
}

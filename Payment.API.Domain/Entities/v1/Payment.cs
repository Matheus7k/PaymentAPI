namespace Payment.API.Domain.Entities.v1
{
    public class Payment
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string PaymentForm { get; set; }
        public double Price { get; set; }
    }
}

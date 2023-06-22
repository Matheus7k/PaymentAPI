namespace Payment.API.Domain.Commands.Order.v1.Create
{
    public class CreateOrderCommand
    {
        public CreateOrderCommand(string productName, int quantity, double unitPrice)
        {
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}

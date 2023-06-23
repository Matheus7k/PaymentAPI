﻿using MediatR;

namespace Payment.API.Domain.Commands.Order.v1.Create
{
    public class CreateOrderCommand : IRequest<Entities.v1.Order>
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

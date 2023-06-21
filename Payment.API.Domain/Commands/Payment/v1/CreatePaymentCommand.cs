﻿namespace Payment.API.Domain.Commands.Payment.v1
{
    public class CreatePaymentCommand
    {
        public CreatePaymentCommand(string cpf, double price, string paymentForm)
        {
            Cpf = cpf;
            Price = price;
            PaymentForm = paymentForm;
        }

        public string Cpf { get; set; }
        public double Price { get; set; }
        public string PaymentForm { get; set; }
    }
}
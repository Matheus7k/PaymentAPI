﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Payment.API.Domain.Commands.Payment.v1.Create
{
    public class CreatePaymentCommand : IRequest<ActionResult<Entities.v1.Payment>>
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

﻿using Payment.API.Domain.Contracts.v1;

namespace Payment.API.Domain.Strategies.v1
{
    public class CreditStrategy : IStrategy
    {
        public double Pay(double price)
        {
            return price += price * 0.15;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SaltpayBank.Domain.AccountAggregate.ValueObjects
{
    public struct Money
    {
        public Currency Currency { get; set; }
        public decimal Amount { get; set; }

        public Money(decimal amount, Currency currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }
    }
}

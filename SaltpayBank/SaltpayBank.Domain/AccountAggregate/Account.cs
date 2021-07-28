using SaltpayBank.Domain.AccountAggregate.ValueObjects;
using SaltpayBank.Seedwork;
using System.Collections.Generic;

namespace SaltpayBank.Domain.AccountAggregate
{
    public class Account : BaseEntity
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public Customer Customer { get; set; }
    }
}
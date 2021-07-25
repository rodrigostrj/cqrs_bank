using SaltpayBank.Domain.AccountAggregate.ValueObjects;

namespace SaltpayBank.Domain.AccountAggregate
{
    public class Account
    {
        public int Id { get; set; }
        public Money Money { get; set; }
        public Customer Customer { get; set; }
    }
}
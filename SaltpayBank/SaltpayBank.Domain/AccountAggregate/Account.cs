using SaltpayBank.Domain.AccountAggregate.ValueObjects;
using SaltpayBank.Seedwork;

namespace SaltpayBank.Domain.AccountAggregate
{
    public class Account : BaseEntity
    {
        public int Id { get; set; }
        public Money Money { get; set; }
        public Customer Customer { get; set; }
    }
}
using SaltpayBank.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltpayBank.Domain.AccountAggregate
{
    public class Customer : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IReadOnlyList<Account> AccountList { get; set; }
    }
}

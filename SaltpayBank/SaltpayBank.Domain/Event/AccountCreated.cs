using SaltpayBank.Domain.AccountAggregate;
using SaltpayBank.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Domain.Event
{
    public class AccountCreated :  IDomainEvent
    {
        public Account Account { get; }

        public AccountCreated(Account account)
        {
            this.Account = account;
        }
    }
}

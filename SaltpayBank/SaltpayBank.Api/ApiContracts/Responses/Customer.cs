using SaltpayBank.Domain.AccountAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaltpayBank.Api.ApiContracts.Responses
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerator<Account> AccountList { get; set; }
    }
}

using SaltpayBank.Domain.AccountAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Application.Events
{
    public class NewAccountMessage
    {
        public Customer Customer { get; set; }
        public decimal Amount { get; set; }
    }
}

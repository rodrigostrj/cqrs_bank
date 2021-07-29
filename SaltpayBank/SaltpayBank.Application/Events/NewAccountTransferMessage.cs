using SaltpayBank.Domain.AccountAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Application.Events
{
    public class NewAccountTransferMessage
    {
        public Account AccountOrigin { get; set; }
        public Account AccountDestitny { get; set; }
        public decimal Amount { get; set; }
    }
}

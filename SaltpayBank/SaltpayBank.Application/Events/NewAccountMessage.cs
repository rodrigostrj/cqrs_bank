using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Application.Events
{
    public class NewAccountMessage
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }
}

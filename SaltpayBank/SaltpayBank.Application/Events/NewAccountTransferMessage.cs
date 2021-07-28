using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Application.Events
{
    public class NewAccountTransferMessage
    {
        public int AccountOriginId { get; set; }
        public int AccountDestitnyId { get; set; }
        public decimal Amount { get; set; }
    }
}

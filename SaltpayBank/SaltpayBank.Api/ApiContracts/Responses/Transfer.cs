using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaltpayBank.Api.ApiContracts.Responses
{
    public class Transfer
    {
        public decimal Amount { get; set; }
        public decimal AmountBeforeTransfer { get; set; }
        public DateTime DateTransfer { get; set; }
    }
}

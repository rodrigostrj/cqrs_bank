using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaltpayBank.Api.ApiContracts.Requests
{
    public class AddNewAccountTransferRequest
    {
        public int AccountOriginId { get; set; }
        public int AccountDestinyId { get; set; }
        public decimal Amount { get; set; }
    }
}

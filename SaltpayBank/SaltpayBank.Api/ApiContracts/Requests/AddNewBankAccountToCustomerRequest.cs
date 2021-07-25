using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaltpayBank.Api.ApiContracts.Requests
{
    public class AddNewBankAccountToCustomerRequest
    {
        public decimal Amount { get; set; }
    }
}

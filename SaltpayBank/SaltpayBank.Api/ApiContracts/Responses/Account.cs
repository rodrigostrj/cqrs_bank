﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaltpayBank.Api.ApiContracts.Responses
{
    public class Balance
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
    }
}

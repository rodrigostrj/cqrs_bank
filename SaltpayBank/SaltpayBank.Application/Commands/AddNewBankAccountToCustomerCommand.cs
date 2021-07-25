using MediatR;
using SaltpayBank.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Application.Commands
{
    public class AddNewBankAccountToCustomerCommand : IRequest<bool>
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }

        public AddNewBankAccountToCustomerCommand(int customerId, decimal amount)
        {
            this.CustomerId = customerId;
            this.Amount = amount;
        }
    }
}

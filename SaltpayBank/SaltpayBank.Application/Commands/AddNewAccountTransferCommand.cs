using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Application.Commands
{
    public class AddNewAccountTransferCommand : IRequest<bool>
    {
        public int AccountOriginId { get; set; }
        public int AccountDestitnyId { get; set; }
        public decimal Amount { get; set; }

        public AddNewAccountTransferCommand(int accountOriginId, int accountDestinyId, decimal amount)
        {
            AccountOriginId = accountOriginId;
            AccountDestitnyId = accountDestinyId;
            Amount = amount;
        }
    }
}

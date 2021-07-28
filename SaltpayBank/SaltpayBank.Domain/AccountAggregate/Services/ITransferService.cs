using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Domain.AccountAggregate.Services
{
    public interface ITransferService
    {
        // Trasfer 
        void AccountAmountTransfer(Transfer transfer);

        IEnumerable<Transfer> GetTransfers(Customer customer);
    }
}

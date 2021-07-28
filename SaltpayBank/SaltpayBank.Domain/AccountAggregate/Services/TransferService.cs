using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Domain.AccountAggregate.Services
{
    public class TransferService : ITransferService
    {
        public void AccountAmountTransfer(Transfer transfer)
        {
            // throw new NotImplementedException();
        }

        public IEnumerable<Transfer> GetTransfers(Customer customer)
        {
            return null;
        }
    }
}

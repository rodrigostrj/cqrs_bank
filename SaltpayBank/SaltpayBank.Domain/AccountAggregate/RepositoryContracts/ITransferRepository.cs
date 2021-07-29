using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Domain.AccountAggregate.RepositoryContracts
{
    public interface ITransferRepository
    {
        void Save(Transfer transfer);
        List<Transfer> GetTransferList(int accountId);
    }
}

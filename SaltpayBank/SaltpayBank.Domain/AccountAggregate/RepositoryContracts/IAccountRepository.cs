using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Domain.AccountAggregate.RepositoryContracts
{
    public interface IAccountRepository
    {
        void Save(Account account);
        Account Get(int accountId);
    }
}

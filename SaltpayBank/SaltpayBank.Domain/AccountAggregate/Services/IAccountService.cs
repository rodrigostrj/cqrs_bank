using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Domain.AccountAggregate.Services
{
    public interface IAccountService
    {
        void CreateBankAccount(Account account);
        Account GetAccount(Customer customer);
    }
}

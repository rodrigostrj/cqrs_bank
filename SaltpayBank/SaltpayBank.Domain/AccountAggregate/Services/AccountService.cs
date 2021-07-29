using SaltpayBank.Domain.AccountAggregate.RepositoryContracts;
using SaltpayBank.Seedwork.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Domain.AccountAggregate.Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;
        private IUnitOfWork _unitiOfWork;

        public AccountService(
            IAccountRepository accountRepository,
            IUnitOfWork unitiOfWork)
        {
            _accountRepository = accountRepository;
            _unitiOfWork = unitiOfWork;
        }

        public void CreateBankAccount(Account account)
        {
            _accountRepository.Save(account);
        }

        public Account GetAccount(int accountId)
        {
            return _accountRepository.Get(accountId);
        }
    }
}

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
            _unitiOfWork.BeginTransaction();
            _accountRepository.Save(account);
            _unitiOfWork.Commit();
        }

        public Account GetAccount(int customerId)
        {
            return _accountRepository.Get(customerId);
        }
    }
}

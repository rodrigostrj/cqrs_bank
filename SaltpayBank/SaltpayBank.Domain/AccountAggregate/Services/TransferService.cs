using SaltpayBank.Domain.AccountAggregate.RepositoryContracts;
using SaltpayBank.Seedwork.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Domain.AccountAggregate.Services
{
    public class TransferService : ITransferService
    {
        private ITransferRepository _transferRepository;
        private IUnitOfWork _unitOfWork;
        private IAccountRepository _accountRepository;

        public TransferService(
            ITransferRepository transferRepository,
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork)
        {
            _transferRepository = transferRepository;
            _unitOfWork = unitOfWork;
            _accountRepository = accountRepository;
        }

        public void AccountAmountTransfer(Transfer transfer)
        {
            // Origin 
            var accountOrigin = _accountRepository.Get(transfer.OriginAccount.Id);
            transfer.OriginAccountAmountBeforeTransfer = accountOrigin.Amount;
            transfer.DateTransfer = DateTime.Now;
            accountOrigin.Amount = accountOrigin.Amount - transfer.AmountToTransfer;

            // Destiny
            var accountDestiny = _accountRepository.Get(transfer.DestinyAccount.Id);
            accountDestiny.Amount = accountDestiny.Amount + transfer.AmountToTransfer;

            transfer.Validate();
            if (transfer.Invalid)
            {
                return;
            }

            _accountRepository.Save(accountOrigin);
            _accountRepository.Save(accountDestiny);
            _transferRepository.Save(transfer);
        }

        public IEnumerable<Transfer> GetTransfers(int accountId)
        {
            return this._transferRepository.GetTransferList(accountId);
        }
    }
}

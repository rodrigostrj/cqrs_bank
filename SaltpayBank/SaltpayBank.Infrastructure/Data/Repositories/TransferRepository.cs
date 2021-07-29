using Dapper;
using SaltpayBank.Domain.AccountAggregate;
using SaltpayBank.Domain.AccountAggregate.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Infrastructure.Data.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private DbSession _session;

        public TransferRepository(DbSession session)
        {
            _session = session;
        }

        public List<Transfer> GetTransferList(int accountId)
        {
            var result = _session.Connection.Query(
                $"SELECT " +
                $" Id, " +
                $" AmountToTransfer," +
                $" OriginAccountAmountBeforeTransfer," +
                $" DateTransfer" +
                $" From Transfers" +
                $" Where OriginAccount_id = {accountId}", null, _session.Transaction);

            var transferHistory = new List<Transfer>();

            foreach (var item in result)
            {
                transferHistory.Add(new Transfer {
                    AmountToTransfer = item.AmountToTransfer,
                    DateTransfer = item.DateTransfer,
                    OriginAccountAmountBeforeTransfer = item.OriginAccountAmountBeforeTransfer,
                });
            }

            return transferHistory;
        }

        public void Save(Transfer transfer)
        {
            try
            {
                if (transfer.Id == 0)
                {
                    _session.Connection.Execute(
                        $"INSERT INTO [Transfers]" +
                        $" (AmountToTransfer, " +
                        $"OriginAccountAmountBeforeTransfer, " +
                        $"DateTransfer," +
                        $"OriginAccount_id, " +
                        $"DestinyAccount_id)" +
                        $"VALUES(" +
                        $"'{transfer.AmountToTransfer}'," +
                        $"'{transfer.OriginAccountAmountBeforeTransfer}'," +
                        $"'{transfer.DateTransfer}'," +
                        $"'{transfer.OriginAccount.Id}'," +
                        $"'{transfer.DestinyAccount.Id}')", null, _session.Transaction);
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

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
                $"SELECT  = {accountId}", null, _session.Transaction).FirstOrDefault();

            return result;
        }

        public void Save(Transfer transfer)
        {
            //if (transfer.Id == 0)
            //{
            //    _session.Connection.Execute(
            //        $"INSERT INTO [Transfers] (, Amount) VALUES({account.Customer.Id}, {account.Amount})", null, _session.Transaction);
            //    return;
            //}
        }
    }
}

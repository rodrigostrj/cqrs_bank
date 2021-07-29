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
    public class AccountRepository : IAccountRepository
    {
        private DbSession _session;

        public AccountRepository(DbSession session)
        {
            _session = session;
        }

        public Account Get(int accountId)
        {
            var result = _session.Connection.Query(
                $"SELECT a.Id, a.Amount, c.Name as CustomerName FROM [Accounts] a " +
                $"Inner Join Customers c on a.CustomerId = c.Id" +
                $"Where Id = '{accountId}'", null, _session.Transaction).FirstOrDefault();

            return result;
        }

        public void Save(Account account)
        {
            if (account.Id == 0)
            {
                _session.Connection.Execute(
                    $"INSERT INTO [Accounts] (CustomerId, Amount) VALUES('{account.Customer.Id}', '{account.Amount}')", null, _session.Transaction);
                return;
            }

            _session.Connection.Execute(
                    $"Update [Accounts] set Amount = '{account.Amount}')" +
                    $"WHERE Id = '{account.Id}'", null, _session.Transaction);
        }
    }
}


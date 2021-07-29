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
                $"SELECT Id as Id, Amount as Amount, Customer_Id as Customer_Id  FROM [Accounts] " +
                $"Where Id = '{accountId}'", null, _session.Transaction).FirstOrDefault();

            var resultCustomer = _session.Connection.Query(
                $"SELECT Id as Id, Name as Name FROM [Customers] " +
                $"Where Id = '{result.Customer_Id}'", null, _session.Transaction).FirstOrDefault();

            return new Account {
                Id = result.Id,
                Amount = result.Amount,
                Customer = new Customer
                {
                    Id = resultCustomer.Id,
                    Name = resultCustomer.Name
                }
            };
        }

        public void Save(Account account)
        {
            if (account.Id == 0)
            {
                _session.Connection.Execute(
                    $"INSERT INTO [Accounts] (Customer_Id, Amount) VALUES('{account.Customer.Id}', '{account.Amount}')", null, _session.Transaction);
                return;
            }

            _session.Connection.Execute(
                    $"Update [Accounts] set Amount = '{account.Amount}' " +
                    $"WHERE Id = '{account.Id}'", null, _session.Transaction);
        }
    }
}


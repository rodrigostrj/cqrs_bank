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
    public class CustomerRepository : ICustomerRepository
    {
        private DbSession _session;

        public CustomerRepository(DbSession session)
        {
            _session = session;
        }

        public Customer Get(int customerId)
        {
            return _session.Connection.Query<Customer>(
                $"SELECT Id, Name FROM [Customers] Where Id = '{customerId}'", null, _session.Transaction).FirstOrDefault();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _session.Connection.Query<Customer>(
                $"SELECT Id, Name FROM [Customers]", null, _session.Transaction);
        }

        public void Save(Customer customer)
        {
            _session.Connection.Execute(
                $"INSERT INTO [Customers] (Id, Name)  VALUES('{customer.Id}', '{customer.Name}')", null, _session.Transaction);
        }
    }
}

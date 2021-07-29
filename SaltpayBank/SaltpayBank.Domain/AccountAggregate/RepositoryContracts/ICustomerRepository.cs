using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Domain.AccountAggregate.RepositoryContracts
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);
        Customer Get(int customerId);
        IEnumerable<Customer> GetCustomers();
    }
}

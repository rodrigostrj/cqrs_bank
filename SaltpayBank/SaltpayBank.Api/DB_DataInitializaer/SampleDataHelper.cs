using Dapper;
using SaltpayBank.Domain.AccountAggregate;
using SaltpayBank.Domain.AccountAggregate.RepositoryContracts;
using SaltpayBank.Infrastructure.Data;
using SaltpayBank.Seedwork.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SaltpayBank.Api.DB_DataInitializaer
{
    public class SampleDataHelper
    {
        private DbSession _session;
        private ICustomerRepository _customerRepository;
        private IUnitOfWork _unitOfWork;

        public SampleDataHelper(
            DbSession session,
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _session = session;
        }

        public void Setup()
        {
            var script = File.ReadAllText(@".\DB_DataInitializaer\DataStructure.sql");

            _unitOfWork.BeginTransaction();
            _session.Connection.Execute(script, null, _session.Transaction);
            _unitOfWork.Commit();

            var customers = _customerRepository.GetCustomers();

            _unitOfWork.BeginTransaction();
            if (customers.Count() == 0)
            {
                foreach (var item in GetCustomers())
                {
                    _customerRepository.Save(item);
                }
            }
            _unitOfWork.Commit();
        }

        private static IList<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{ Id = 1, Name = "Arisha Barron"},
                new Customer{ Id = 2, Name = "Branden Gibson"},
                new Customer{ Id = 3, Name = "Rhonda Church"},
                new Customer{ Id = 4, Name = "Georgina Hazel"}
            };
        }
    }
}

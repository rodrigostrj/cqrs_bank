using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaltpayBank.Domain.AccountAggregate;
using System.Collections.Generic;

namespace SaltpayBank.Domain.UnitTests
{
    [TestClass]
    public class AccountDomainModel_Tests
    {
        private Account _account;

        public AccountDomainModel_Tests()
        {
            var account = _account;

            _account = new Account
            {
                Amount = 1,
                Customer = new Customer { Name = "XPTO", AccountList = new List<Account> { new Account { Amount = 1 } } }
            };
        }

        [TestMethod]
        public void Account_Valid()
        {
            var account = _account;

            // Act
            account.Validate();

            // Assert
            Assert.IsFalse(account.Invalid);
            Assert.IsTrue(account.ValidationResult.Errors.Count == 0);
        }

        [TestMethod]
        public void Account_With_Value_Lower_Than_Zero()
        {
            var account = _account;
            account.Amount = -1;

            // Act
            account.Validate();

            // Assert
            Assert.IsTrue(account.Invalid);
            Assert.IsTrue(account.ValidationResult.Errors.Count == 1);
        }

        [TestMethod]
        public void Account_Without_Customer_And_With_Value_Lower_Than_Zero()
        {
            var account = _account;
            account.Customer = null;
            account.Amount = 0;

            // Act
            account.Validate();

            // Assert
            Assert.IsTrue(account.Invalid);
            Assert.IsTrue(account.ValidationResult.Errors.Count == 2);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaltpayBank.Domain.AccountAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Domain.UnitTests
{
    [TestClass]
    public class Transfer_Tests
    {
        private Account _originAccount;
        private Account _destinyAccount;
        private Transfer _transfer;

        public Transfer_Tests()
        {
            _originAccount = new Account { Id = 1, Amount = 11 };
            _destinyAccount = new Account { Id = 2, Amount = 5 };
            _transfer = new Transfer
            {
                DateTransfer = DateTime.Now,
                AmountToTransfer = 10,
                OriginAccount = _originAccount,
                DestinyAccount = _destinyAccount,
                OriginAccountAmountBeforeTransfer = _originAccount.Amount
            };
        }

        [TestMethod]
        public void Account_Valid()
        {
            var transfer = _transfer;

            // Act
            transfer.Validate();

            // Assert
            Assert.IsFalse(transfer.Invalid);
            Assert.IsTrue(transfer.ValidationResult.Errors.Count == 0);
        }

        [TestMethod]
        public void Transfer_With_Amount_To_Transfer_Lower_Than_Zero()
        {
            var transfer = _transfer;
            transfer.AmountToTransfer = -1;

            // Act
            transfer.Validate();

            // Assert
            Assert.IsTrue(transfer.Invalid);
            Assert.IsTrue(transfer.ValidationResult.Errors.Count == 1);
        }

        [TestMethod]
        public void Transfer_With_Equal_Accounts()
        {
            var transfer = _transfer;
            transfer.DestinyAccount = _originAccount;

            // Act
            transfer.Validate();

            // Assert
            Assert.IsTrue(transfer.Invalid);
            Assert.IsTrue(transfer.ValidationResult.Errors.Count == 1);
        }
    }
}

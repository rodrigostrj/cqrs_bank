using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SaltpayBank.Domain.AccountAggregate;
using SaltpayBank.Domain.AccountAggregate.RepositoryContracts;
using SaltpayBank.Domain.AccountAggregate.Services;
using SaltpayBank.Seedwork.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Domain.UnitTests
{
    [TestClass]
    public class TransferService_Tests
    {
        private ITransferService _transferService;
        private Mock<ITransferRepository> _transferRepositoryMock;
        private Mock<IAccountRepository> _accountRepositoryMock;
        private Mock<IUnitOfWork> _unityOfRepositoryMock;

        public TransferService_Tests()
        {
            _transferRepositoryMock = new Mock<ITransferRepository>();
            _accountRepositoryMock = new Mock<IAccountRepository>();
            _unityOfRepositoryMock = new Mock<IUnitOfWork>();
            _transferService = GetTransferServiceMOckedInstance();
        }

        private ITransferService GetTransferServiceMOckedInstance()
        {
            return new TransferService(
                    _transferRepositoryMock.Object,
                    _accountRepositoryMock.Object,
                    _unityOfRepositoryMock.Object
                );
        }

        [TestMethod]
        public void Success_On_Transfer_Test()
        {
            var originAccount = new Account { Id = 1, Amount = 10 };
            var destinyAccount = new Account { Id = 2, Amount = 1 };

            var transfer = new Transfer
            { 
                AmountToTransfer = 5,
                OriginAccount = originAccount,
                DestinyAccount = destinyAccount
            };

            _accountRepositoryMock.Setup(x => x.Get(1)).Returns(originAccount);
            _accountRepositoryMock.Setup(x => x.Get(2)).Returns(destinyAccount);
            
            // Act
            _transferService.AccountAmountTransfer(transfer);


            // Asssert
            _accountRepositoryMock.Verify(m => m.Save(It.IsAny<Account>()), Times.AtLeast(2));
            _transferRepositoryMock.Verify(m => m.Save(It.IsAny<Transfer>()), Times.AtLeast(1));
        }
    }
}


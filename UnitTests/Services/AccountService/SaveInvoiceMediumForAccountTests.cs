using System.Collections.Generic;
using System.Linq;
using Accounts.Api.Entities;
using Accounts.Api.Repositories.Interfaces;
using Accounts.Api.Services.Interfaces;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Accounts.Api.UnitTests.Services.AccountService
{
    [TestClass]
    public class SaveInvoiceMediumForAccountTests
    {
        private Mock<IAccountsRepository> _accountsRepository;
        private Mock<IValidator<Account>> _accountValidator;
        private IAccountsService _accountsService;

        [TestInitialize]
        public void SetUp()
        {
            _accountsRepository = new Mock<IAccountsRepository>();
            _accountValidator = new Mock<IValidator<Account>>();
            _accountsService = new Accounts.Api.Services.AccountsService(_accountsRepository.Object, _accountValidator.Object);
        }

        [TestMethod]
        public void SaveInvoiceMediumForAccount_UpdatesMediumType_IfAccountFound()
        {
            // Arrange
            _accountsRepository.Setup(repository => repository.Accounts).Returns(new List<Account>
            {
                new Account {AccountId = 1}
            }.AsQueryable());

            // Act
            _accountsService.SaveInvoiceMediumForAccount(1, "Text");

            // Assert
            _accountsRepository.Verify(repository => repository.Save(It.IsAny<Account>()), Times.Once);
        }

        [TestMethod]
        public void SaveInvoiceMediumForAccount_ThrowsException_IfAccountNotFound()
        {
            // Arrange

            // Act
            // Assert
            Assert.ThrowsException<ValidationException>(() => _accountsService.SaveInvoiceMediumForAccount(1, "Text"));
        }
    }
}
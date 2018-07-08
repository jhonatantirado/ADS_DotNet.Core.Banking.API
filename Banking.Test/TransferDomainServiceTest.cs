
namespace Banking.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BankAccount.Domain.Entity;
    using Transactions.Domain.Service;
    using System;

    [TestClass]
    public class UnitTest1
    {
        private TransactionDomainService transferDomainService = new TransactionDomainService();
        private string originBankAccountNumber = "123-456-001";
        private string destinationBankAccountNumber = "123-456-002";

        [TestMethod]
        public void performTransferSuccess()
        {

            //arrange
            BankAccount originBankAccount = createAccount(originBankAccountNumber, 100);
            BankAccount destinationBankAccount = createAccount(destinationBankAccountNumber, 10);

            //act
            transferDomainService.performTransfer(originBankAccount, destinationBankAccount, 10);

            //assert
            Assert.AreEqual(90, originBankAccount.Balance);
            Assert.AreEqual(20, destinationBankAccount.Balance);

        }

        [TestMethod]
        public void performTransferErrorSameAccount()
        {
            //arrange
            BankAccount originBankAccount = createAccount(originBankAccountNumber, 100m);
            BankAccount destinationBankAccount = createAccount(originBankAccountNumber, 10m);

            //act
            var exception = ExceptionAssert.Throws<Exception>(
                () => transferDomainService.performTransfer(originBankAccount, destinationBankAccount, 10m)
                );

            //assert
            Assert.AreEqual(exception.GetType(), typeof(ArgumentException));

        }

        [TestMethod]
        public void performTransferErrorEmptyAccount()
        {
            //arrange
            BankAccount originBankAccount = null;
            BankAccount destinationBankAccount = null;

            //act
            var exception = ExceptionAssert.Throws<Exception>(
                () => transferDomainService.performTransfer(originBankAccount, destinationBankAccount, 10m)
                );

            //assert
            Assert.AreEqual(exception.GetType(), typeof(ArgumentException));

        }

        [TestMethod]
        public void performTransferErrorLockedDestinationAccount()
        {
            //arrange
            BankAccount originBankAccount = createAccount(originBankAccountNumber, 100m);
            BankAccount destinationBankAccount = createAccount(destinationBankAccountNumber, 10);
            destinationBankAccount.lockAccount();

            //act
            var exception = ExceptionAssert.Throws<Exception>(
                () => transferDomainService.performTransfer(originBankAccount, destinationBankAccount, 10m)
                );

            //assert
            Assert.AreEqual(exception.GetType(), typeof(ArgumentException));

        }

        [TestMethod]
        public void performTransferErrorNoMoneyOriginAccount()
        {
            //arrange
            BankAccount originBankAccount = createAccount(originBankAccountNumber, 5m);
            BankAccount destinationBankAccount = createAccount(destinationBankAccountNumber, 10m);

            //act
            var exception = ExceptionAssert.Throws<Exception>(
                () => transferDomainService.performTransfer(originBankAccount, destinationBankAccount, 10m)
                );

            //assert
            Assert.AreEqual(exception.GetType(), typeof(ArgumentException));

        }


        [TestMethod]
        public void performTransferErrorNegativeTransference()
        {
            //arrange
            BankAccount originBankAccount = createAccount(originBankAccountNumber, 5m);
            BankAccount destinationBankAccount = createAccount(destinationBankAccountNumber, 10m);

            //act
            var exception = ExceptionAssert.Throws<Exception>(
                () => transferDomainService.performTransfer(originBankAccount, destinationBankAccount, -10m)
                );

            //assert
            Assert.AreEqual(exception.GetType(), typeof(ArgumentException));

        }


        #region Helpers
        BankAccount createAccount(string number, decimal balance)
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.Balance = balance;
            bankAccount.Number = number;
            return bankAccount;
        }
        #endregion


    }
}


namespace Banking.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BankAccount.Domain.Entity;
    using Transactions.Domain.Service;

    [TestClass]
    public class UnitTest1
    {
        private TransferDomainService transferDomainService = new TransferDomainService();
        private string originBankAccountNumber = "123-456-001";
        private string destinationBankAccountNumber = "123-456-002";

        [TestMethod]
        public void performTransferSuccess()
        {
            try
            {
                BankAccount originBankAccount = createAccount(originBankAccountNumber, 100);
                BankAccount destinationBankAccount = createAccount(destinationBankAccountNumber, 10);
                transferDomainService.performTransfer(originBankAccount, destinationBankAccount, 10);
                Assert.AreEqual(90, originBankAccount.Balance);
                Assert.AreEqual(20, destinationBankAccount.Balance);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

 //       @Test(expected = IllegalArgumentException.class)
	//public void performTransferErrorSameAccount() throws Exception
 //       {
 //           BankAccount originBankAccount = createAccount(originBankAccountNumber, new BigDecimal(100));
	//	BankAccount destinationBankAccount = createAccount(originBankAccountNumber, new BigDecimal(10));
 //       transferDomainService.performTransfer(originBankAccount, destinationBankAccount, new BigDecimal(10));
	//}


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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.Domain.Service
{
    using BankAccount.Domain.Entity;
    using Common.Application;

    public class BankAccountDomainService
    {
        public void validExistBankAccount(BankAccount bankAccount)
        {
            try
            {
                Notification notification = new Notification();
                if (bankAccount == null)
                {
                    notification.addError("Account doesn't exist.");
                    throw new ArgumentException(notification.errorMessage());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        public void validDoesntExistNumberAccount(BankAccount bankAccount)
        {
            try
            {
                Notification notification = new Notification(); 
                if (bankAccount != null)
                {
                    notification.addError("Account already exist.");
                    throw new ArgumentException(notification.errorMessage());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}

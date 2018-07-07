namespace BankAccount.Domain.Entity
{
    using Customer.Domain.Entity;
    using Common.Application;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;


    [Table("bank_account")]
    public class BankAccount
    {

        [Column("bank_account_id", TypeName = "BIGINT")]
        public long Id { get; set; }

        [Required]
        [Column("number", TypeName = "VARCHAR(50)")]
        public string Number { get; set; }

        [Required]
        [Column("balance", TypeName = "DECIMAL(10,2)")]
        public decimal? Balance { get; set; }

        [Required]
        [Column("isLocked", TypeName = "BOOLEAN")]
        public bool IsLocked { get; set; }

        [Column("customer_id", TypeName = "BIGINT")]
        public long CustomerId { get; set; }


        public virtual Customer Customer { get; set; }

        public BankAccount()
        {
        }

        public void lockAccount()
        {
            if (!this.IsLocked)
            {
                this.IsLocked = true;
            }
        }

        public void unLock()
        {
            if (this.IsLocked)
            {
                this.IsLocked = false;
            }
        }

        public bool hasIdentity()
        {
        
            return !string.IsNullOrWhiteSpace(this.Number);
        }

        public void withdrawMoney(decimal? amount)
        {
            Notification notification = this.withdrawValidation(amount);
            if (notification.hasErrors())
            {
                throw new ArgumentException(notification.errorMessage());
            }
            this.Balance = this.Balance - amount;
        }

        public void depositMoney(decimal? amount)
        {
            Notification notification = this.depositValidation(amount);
            if (notification.hasErrors())
            {
                throw new ArgumentException(notification.errorMessage());
            }
            this.Balance = this.Balance + amount;
        }

        public Notification withdrawValidation(decimal? amount)
        {
            Notification notification = new Notification();
            this.validateAmount(notification, amount);
            this.validateBankAccount(notification);
            this.validateBalance(notification, amount);
            return notification;
        }

        public Notification depositValidation(decimal? amount)
        {
            Notification notification = new Notification();
            this.validateAmount(notification, amount);
            this.validateBankAccount(notification);
            return notification;
        }

        private void validateAmount(Notification notification, decimal? amount)
        {
            if (amount == null)
            {
                notification.addError("amount is missing");
                return;
            }
            if (amount <= 0)
            {
                notification.addError("The amount must be greater than zero");
            }
        }

        private void validateBankAccount(Notification notification)
        {
            if (!this.hasIdentity())
            {
                notification.addError("The account has no identity");
            }
            if (this.IsLocked)
            {
                notification.addError("The account is locked");
            }
        }

        private void validateBalance(Notification notification, decimal? amount)
        {
            if (!this.Balance.HasValue)
            {
                notification.addError("balance cannot be null");
            }
            if (!this.canBeWithdrawed(amount))
            {
                notification.addError("Cannot withdraw in the account, amount is greater than balance");
            }
        }

        public bool canBeWithdrawed(decimal? amount)
        {
            return !this.IsLocked && (this.Balance.Value.CompareTo(amount) >= 0);
        }

        public Notification validateSaveBankAccount()
        {
            Notification notification = new Notification();

            if (this == null)
            {
                notification.addError("Invalid JSON data in request body.");
            }
            if (!this.hasIdentity())
            {
                notification.addError("Number Account is required.");
            }
            if (!this.Balance.HasValue)
            {
                    notification.addError("Balance Account is required.");             
            }
            
            if (this.CustomerId == 0)
            {
                notification.addError("The Customer is Required");
            }
            return notification;
        }

    }
}
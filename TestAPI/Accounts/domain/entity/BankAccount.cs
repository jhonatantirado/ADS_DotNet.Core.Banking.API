namespace BankAccount.Domain.Entity{
    using Customer.Domain.Entity;
    using Common.Application;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using System.Linq;

    [Table("bank_account")]
    public class BankAccount {

        [Column("bank_account_id")]
        public int Id { get; set; } //private long id;

        [Column("number")]
        public string Number { get; set; }//private string number;

        [Column("balance")]
        public decimal? /*objectType*/Balance { get; set; }//private decimal balance;

        [Column("locked")]
        public bool IsLocked { get; set; }//private bool isLocked;

        [Column("customer_id")]
        public int CustomerId { get; set; }  //private long id;


        public virtual Customer Customer { get; set; }//public /*private*/ Customer customer;

        public BankAccount() {
    }

    public void isLock() {
        if (!this.IsLocked) {
            this.IsLocked = true;
        }
    }

    public void unLock() {
        if (this.IsLocked) {
            this.IsLocked = false;
        }
    }

    public bool hasIdentity() {
        return !this.Number.Trim().Equals("");
    }

    public void withdrawMoney(decimal? amount) {
    	Notification notification = this.withdrawValidation(amount);
        if (notification.hasErrors()) {
            throw new ArgumentException(notification.errorMessage());
        }
        this.Balance = this.Balance - amount;
    }

    public void depositMoney(decimal? amount) {
    	Notification notification = this.depositValidation(amount);
        if (notification.hasErrors()) {
            throw new ArgumentException(notification.errorMessage());
        }
        this.Balance = this.Balance + amount;
    }
    
    public Notification withdrawValidation(decimal? amount) {
    	Notification notification = new Notification();
        this.validateAmount(notification, amount);
        this.validateBankAccount(notification);
        this.validateBalance(notification, amount);
        return notification;
    }
    
    public Notification depositValidation(decimal? amount) {
        Notification notification = new Notification();
        this.validateAmount(notification, amount);
        this.validateBankAccount(notification);
        return notification;
    }
    
    private void validateAmount(Notification notification, decimal? amount) {
        if (amount == null /* decimal.MinValue*/) {
            notification.addError("amount is missing");
            return;
        }
        if (amount <= 0) {
            notification.addError("The amount must be greater than zero");
        }
    }
    
    private void validateBankAccount(Notification notification) {
        if (!this.hasIdentity()) {
            notification.addError("The account has no identity");
        }
        if (this.IsLocked) {
        	notification.addError("The account is locked");
        }
    }
    
    private void validateBalance(Notification notification, decimal? amount) {
        if (!this.Balance.HasValue /*== decimal.MinValue*/) {
            notification.addError("balance cannot be null");
        }
        if (!this.canBeWithdrawed(amount)) {
        	notification.addError("Cannot withdraw in the account, amount is greater than balance");
        }
    }

    public bool canBeWithdrawed(decimal? amount) {
        return !this.IsLocked && (this.Balance.Value.CompareTo(amount) >= 0);
    }

    public long getId() {
        return Id;
    }

    public void setId(int id) {
        this.Id = id;
    }

    public string getNumber() {
        return this.Number;
    }

    public void setNumber(string number) {
        this.Number = number;
    }

    public decimal getBalance() {
        return this.Balance.Value;
    }

    public void setBalance(decimal balance) {
        this.Balance = balance;
    }

    public bool getIsLocked() {
        return IsLocked;
    }
    
    public void setIsLocked(bool isLocked) {
        this.IsLocked = isLocked;
    }

    public Customer getCustomer() {
        return Customer;
    }

    public void setCustomer(Customer customer) {
        this.Customer = customer;
    }
}
}
namespace Customer.Domain.Entity
{
    using BankAccount.Domain.Entity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("customer")]
    public class Customer {

        [Column("customer_id")]       
        public int Id { get; set; }  //private long id;

        [Column("first_name")]
        public string FirstName { get; set; } //private string firstName;

        [Column("last_name")]
        public string LastName { get; set; } //private string lastName;

        [Column("cellphone")]
        public string Cellphone { get; set; } //private string lastName;

        [Column("email")]
        public string Email { get; set; } //private string lastName;

        [Column("document_number")]
        public string DocumentNumber { get; set; } //private string lastName;

        public List<BankAccount> BankAccounts { get; set; } //public /*private*/ List<BankAccount> bankAccounts;

        [Column("isActive")]
        public bool IsActive { get; set; }

        public Customer() {
            this.BankAccounts = new List<BankAccount>();
        }

        public string getFullName() {
            return string.Concat("%s, %s", this.LastName, this.FirstName);
        }

        public long getId() {
            return Id;
        }

        public void setId(int id) {
            this.Id = id;
        }

        public string getFirstName() {
            return FirstName;
        }

        public void setFirstName(string firstName) {
            this.FirstName = firstName;
        }

        public string getLastName() {
            return LastName;
        }

        public void setLastName(string lastName) {
            this.LastName = lastName;
        }

        public List<BankAccount> getBankAccounts() {
            return BankAccounts;
        }

        public void setBankAccounts(List<BankAccount> bankAccounts) {
            this.BankAccounts = bankAccounts;
        }
    }

}

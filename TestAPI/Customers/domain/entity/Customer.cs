namespace Customer.Domain.Entity
{
    using BankAccount.Domain.Entity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("customer")]
    public class Customer {

        [Column("customer_id")]       
        public int Id { get; set; }  

        [Column("first_name")]
        public string FirstName { get; set; } 

        [Column("last_name")]
        public string LastName { get; set; } 

        [Column("cellphone")]
        public string Cellphone { get; set; } 

        [Column("email")]
        public string Email { get; set; }

        [Column("document_number")]
        public string DocumentNumber { get; set; } 

        public List<BankAccount> BankAccounts { get; set; } 

        [Column("isActive")]
        public bool IsActive { get; set; }

        public Customer() {
            this.BankAccounts = new List<BankAccount>();
        }

        public string getFullName() {
            return string.Concat("%s, %s", this.LastName, this.FirstName);
        }

        
    }

}

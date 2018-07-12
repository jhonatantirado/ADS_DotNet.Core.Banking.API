namespace Customer.Domain.Entity
{
    using BankAccount.Domain.Entity;
    using Common.Application;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("customer")]
    public class Customer
    {

        [Column("customer_id", TypeName = "BIGINT")]
        public long Id { get; set; }

        [Required]
        [Column("first_name", TypeName = "VARCHAR(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column("last_name", TypeName = "VARCHAR(50)")]
        public string LastName { get; set; }

        [Column("cellphone", TypeName = "VARCHAR(50)")]
        public string Cellphone { get; set; }


        [Column("email", TypeName = "VARCHAR(50)")]
        public string Email { get; set; }

        [Required]
        [Column("document_number", TypeName = "VARCHAR(50)")]
        public string DocumentNumber { get; set; }

        [Column("birth_Date", TypeName = "DATE")]
        public DateTime? BirthDate { get; set; }

        [Column("isActive", TypeName = "BOOLEAN")]
        public bool IsActive { get; set; }

        [Required]
        [Column("password", TypeName = "VARCHAR(500)")]
        public string Password { get; set; }

        [Required]
        [Column("id_rol", TypeName = "BIGINT")]
        public long id_rol { get; set; }

        [Required]
        [Column("user", TypeName = "VARCHAR(100)")]
        public string User { get; set; }

        public List<BankAccount> BankAccounts { get; set; }


        public Customer()
        {
            this.BankAccounts = new List<BankAccount>();
        }

        public string getFullName()
        {
            return string.Concat("%s, %s", this.LastName, this.FirstName);
        }

        public Notification validateSaveCustomer()
        {
            Notification notification = new Notification();

            if (string.IsNullOrWhiteSpace(this.FirstName))
            {
                notification.addError("First Name is required.");
            }
            if (string.IsNullOrWhiteSpace(this.LastName))
            {
                notification.addError("Last Name is required.");
            }
            if (string.IsNullOrWhiteSpace(this.DocumentNumber))
            {
                notification.addError("Document Number is required.");
            }
            if (string.IsNullOrWhiteSpace(this.Password))
            {
                notification.addError("Password is Required");
            }
            //if (Id_Rol == 0)
            //{
            //    notification.addError("Rol is Required");
            //}
            return notification;
        }

    }

   


    [Table("Role")]
    public class Role
    {
        [Column("id_rol", TypeName = "BIGINT")]
        public long Id { get; set; }

        [Required]
        [Column("role_Name", TypeName = "VARCHAR(100)")]
        public string Role_Name { get; set; }

        [Column("isActive", TypeName = "BOOLEAN")]
        public bool IsActive { get; set; }
    }
}

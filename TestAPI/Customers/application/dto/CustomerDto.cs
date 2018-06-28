namespace Customer.Application.Dto
{
using Common.Application.Dto;
using Common.Application.Enumeration;
using System.Collections.Generic;
using Accounts.Application.Dto;

public class CustomerDto: RequestBaseDto {

        public string FirstName { get; set; } //private string firstName;
        public string LastName { get; set; } //private string lastName;
        private List<BankAccountDto> BankAccounts/*Dto*/;

	public string getFirstName() {
		return FirstName;
	}

	public void setFirstName(string FirstName) {
		this.FirstName = FirstName;
	}

	public string getLastName() {
		return LastName;
	}

	public void setLastName(string LastName) {
		this.LastName = LastName;
	}

	public List<BankAccountDto> getBankAccounts/*Dto*/() {
		return BankAccounts/*Dto*/;
	}

	public void setBankAccounts/*Dto*/(List<BankAccountDto> BankAccounts/*Dto*/) {
		this.BankAccounts/*Dto*/ = BankAccounts/*Dto*/;
	}

	
}

}


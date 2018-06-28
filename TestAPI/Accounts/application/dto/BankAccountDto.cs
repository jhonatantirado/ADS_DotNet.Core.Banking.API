namespace Accounts.Application.Dto{
    using Customer.Application.Dto;
public class BankAccountDto {
	private long id;
	private string number;
	private decimal balance;
	private bool isLocked;
	private CustomerDto customer;

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public string getNumber() {
		return number;
	}

	public void setNumber(string number) {
		this.number = number;
	}

	public decimal getBalance() {
		return balance;
	}

	public void setBalance(decimal balance) {
		this.balance = balance;
	}

	public bool isLock() {
		return isLocked;
	}

	public void setLocked(bool isLocked) {
		this.isLocked = isLocked;
	}

	public CustomerDto getCustomer() {
		return customer;
	}

	public void setCustomer(CustomerDto customer) {
		this.customer = customer;
	}
}

}

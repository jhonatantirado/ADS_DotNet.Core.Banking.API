namespace BankAccount.Application.Dto
{

    using Customer.Application.Dto;

    public class BankAccountDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal? Balance { get; set; }
        public bool IsLocked { get; set; }
        public int CustomerId { get; set; }
        public virtual CustomerDto Customer { get; set; }

    }

}

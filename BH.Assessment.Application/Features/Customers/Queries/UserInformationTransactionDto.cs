namespace BH.Assessment.Application.Features.Customers.Queries;

public class UserInformationTransactionDto
{
    public Guid TransactionId { get; set; }
    public double Amount { get; set; }
    public Guid AccountId { get; set; }
}
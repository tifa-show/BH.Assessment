namespace BH.Assessment.Application.Features.Customers.Queries;

public class UserInformationVm
{
    public Guid CustomerId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public double Balance { get; set; }
    public ICollection<UserInformationTransactionDto> Transactions { get; set; }
}
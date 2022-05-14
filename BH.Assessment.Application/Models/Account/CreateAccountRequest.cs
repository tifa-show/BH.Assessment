namespace BH.Assessment.Application.Models.Account;

public record CreateAccountRequest
{
    public Guid CustomerId { get; init; } = default!;
    public double InitCredit { get; init; } = default!;
}
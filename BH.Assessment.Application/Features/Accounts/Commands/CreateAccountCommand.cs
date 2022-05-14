using MediatR;

namespace BH.Assessment.Application.Features.Accounts.Commands;

public class CreateAccountCommand : IRequest<CreateAccountResponse>
{
    public Guid CustomerId { get; set; }
    public double InitCredit { get; set; }
}
using MediatR;

namespace BH.Assessment.Application.Features.Customers.Queries;

public class GetUserInformationQuery : IRequest<UserInformationVm>
{
    public Guid CustomerId { get; set; }
}
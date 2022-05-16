using BH.Assessment.Application.Response;

namespace BH.Assessment.Application.Features.Customers.Commands;

public class CreateCustomerResponse : BaseResponse
{
    public Guid CustomerId { get; set; }
}
using MediatR;

namespace BH.Assessment.Application.Features.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<CreateCustomerResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Balance { get; set; }
    }
}

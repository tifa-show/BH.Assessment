using AutoMapper;
using BH.Assessment.Application.Contracts.Persistence;
using MediatR;

namespace BH.Assessment.Application.Features.Customers.Queries;

public class GetUserInformationQueryHandler : IRequestHandler<GetUserInformationQuery, UserInformationVm>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetUserInformationQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<UserInformationVm> Handle(GetUserInformationQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.LoadCustomerWithRelatedTransactions(request.CustomerId)
            .ConfigureAwait(false);
        var response = _mapper.Map<UserInformationVm>(customer);

        return response;
    }
}
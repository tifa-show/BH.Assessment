using AutoMapper;
using BH.Assessment.Application.Contracts.Persistence;
using BH.Assessment.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BH.Assessment.Application.Features.Customers.Commands;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger<CreateCustomerCommandHandler> _logger;
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper,
        ILogger<CreateCustomerCommandHandler> logger)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateCustomerResponse();
        var validator = new CreateCustomerCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
        if (validationResult.Errors.Count > 0)
        {
            response.Success = false;
            response.ValidationErrors = validationResult.Errors.Select(m => m.ErrorMessage).ToList();
            _logger.LogError(
                "Unable to create customer");
            return response;
        }

        var customer = _mapper.Map<Customer>(request);
        await _customerRepository.AddAsync(customer).ConfigureAwait(false);
        response.CustomerId = customer.Id;
        return response;
    }
}
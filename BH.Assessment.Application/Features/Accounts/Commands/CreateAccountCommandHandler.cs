using AutoMapper;
using BH.Assessment.Application.Contracts.Persistence;
using BH.Assessment.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BH.Assessment.Application.Features.Accounts.Commands;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, CreateAccountResponse>
{
    private readonly IAccountRepository _accountRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger<CreateAccountCommandHandler> _logger;
    private readonly IMapper _mapper;

    public CreateAccountCommandHandler(IMapper mapper, IAccountRepository accountRepository,
        ICustomerRepository customerRepository, ILogger<CreateAccountCommandHandler> logger)
    {
        _mapper = mapper;
        _accountRepository = accountRepository;
        _customerRepository = customerRepository;
        _logger = logger;
    }

    public async Task<CreateAccountResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateAccountResponse();
        var validator = new CreateAccountCommandValidator(_customerRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);

        if (validationResult.Errors.Count > 0)
        {
            response.Success = false;
            response.ValidationErrors = validationResult.Errors.Select(m => m.ErrorMessage).ToList();
            _logger.LogError(
                "Unable to create account for specified customer due to this errors");
            return response;
        }

        var account = new Account
        { CustomerId = request.CustomerId, AccountType = AccountType.CurrentAccount, Code = string.Empty };
        if (request.InitCredit > 0)
        {
            var transaction = _mapper.Map<Transaction>(request);
            account.Transactions.Add(transaction);
        }

        await _accountRepository.AddAsync(account).ConfigureAwait(false);
        response.Account = _mapper.Map<CreateAccountDto>(account);

        return response;
    }
}
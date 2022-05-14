﻿using AutoMapper;
using BH.Assessment.Application.Contracts.Persistence;
using BH.Assessment.Domain.Entities;
using MediatR;

namespace BH.Assessment.Application.Features.Accounts.Commands;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, CreateAccountResponse>
{
    private readonly IAccountRepository _accountRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CreateAccountCommandHandler(IMapper mapper, IAccountRepository accountRepository,
        ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _accountRepository = accountRepository;
        _customerRepository = customerRepository;
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
            return response;
        }

        var account = new Account { CustomerId = request.CustomerId, AccountType = AccountType.CurrentAccount };
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
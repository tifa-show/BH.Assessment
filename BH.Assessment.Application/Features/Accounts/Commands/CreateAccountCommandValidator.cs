using BH.Assessment.Application.Contracts.Persistence;
using FluentValidation;

namespace BH.Assessment.Application.Features.Accounts.Commands;

public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateAccountCommandValidator(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
        RuleFor(m => m)
            .MustAsync(IsCustomerExist)
            .WithMessage("There is No Customer with Specified Id");
    }

    public async Task<bool> IsCustomerExist(CreateAccountCommand command, CancellationToken cancellationToken)
    {
        return !await _customerRepository.IsCustomerExist(command.CustomerId).ConfigureAwait(false);
    }
}
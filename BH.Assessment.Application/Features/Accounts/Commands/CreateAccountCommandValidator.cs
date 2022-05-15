using BH.Assessment.Application.Contracts.Persistence;
using FluentValidation;

namespace BH.Assessment.Application.Features.Accounts.Commands;

public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateAccountCommandValidator(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
        RuleFor(m => m.CustomerId)
           .MustAsync(IsCustomerExist).WithMessage("There is No Customer with Specified Id");

        // todo: fixing the error of sending multiple error messages 
        RuleFor(m => m)
            .MustAsync(IsConnectedWithExistedAccount).WithMessage("The User Has Already Account Integrated with");
    }

    public async Task<bool> IsCustomerExist(Guid customerId, CancellationToken cancellationToken)
    {
        return await _customerRepository.IsCustomerExist(customerId).ConfigureAwait(false);
    }

    public async Task<bool> IsConnectedWithExistedAccount(CreateAccountCommand command,
        CancellationToken cancellationToken)
    {
        return !await _customerRepository.IsConnectedWithOtherAccount(command.CustomerId);
    }
}
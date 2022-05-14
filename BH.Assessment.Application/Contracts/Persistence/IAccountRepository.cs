using BH.Assessment.Application.Models.Account;
using BH.Assessment.Domain.Entities;

namespace BH.Assessment.Application.Contracts.Persistence;

public interface IAccountRepository : IAsyncRepository<Account>
{
    Task<Account> CreateAccountForExistingCustomer(CreateAccountRequest request);
}
using BH.Assessment.Domain.Entities;

namespace BH.Assessment.Application.Contracts.Persistence;

public interface ICustomerRepository : IAsyncRepository<Customer>
{
    Task<bool> IsCustomerExist(Guid id);
    Task<Customer> LoadCustomerWithRelatedTransactions(Guid id);
}
using BH.Assessment.Domain.Entities;

namespace BH.Assessment.Application.Contracts.Persistence;

public interface ITransactionRepository : IAsyncRepository<Transaction>
{
}
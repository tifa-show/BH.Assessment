using BH.Assessment.Application.Contracts.Persistence;
using BH.Assessment.Domain.Entities;

namespace BH.Assessment.Persistence.Persistence;

public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(BhAssessmentContext context) : base(context)
    {
    }
}
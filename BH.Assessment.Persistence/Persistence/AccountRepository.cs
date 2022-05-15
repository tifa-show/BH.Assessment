using BH.Assessment.Application.Contracts.Persistence;
using BH.Assessment.Domain.Entities;

namespace BH.Assessment.Persistence.Persistence;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(BhAssessmentContext context) : base(context)
    {
    }
}
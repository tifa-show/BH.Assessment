using BH.Assessment.Application.Contracts.Persistence;
using BH.Assessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BH.Assessment.Persistence.Persistence;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    private readonly BhAssessmentContext _context;

    public CustomerRepository(BhAssessmentContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> IsCustomerExist(Guid id)
    {
        return await _context.Customers.AnyAsync(m => m.Id == id).ConfigureAwait(false);
    }

    public async Task<bool> IsConnectedWithOtherAccount(Guid id)
    {
        var data = await _context.Customers.FindAsync(id).ConfigureAwait(false);
        return data?.Account is null;
    }

    public async Task<Customer> LoadCustomerWithRelatedTransactions(Guid id)
    {
        return await _context.Customers
            .Include(m => m.Account)
            .ThenInclude(m => m.Transactions)
            .FirstOrDefaultAsync(m => m.Id == id)
            .ConfigureAwait(false);
    }
}
using BH.Assessment.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BH.Assessment.Persistence.Persistence;

public class BaseRepository<T> : IAsyncRepository<T> where T : class
{
    private readonly BhAssessmentContext _context;

    public BaseRepository(BhAssessmentContext context)
    {
        _context = context;
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id).ConfigureAwait(false);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _context.Set<T>().ToListAsync().ConfigureAwait(false);
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity).ConfigureAwait(false);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}
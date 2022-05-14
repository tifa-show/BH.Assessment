using BH.Assessment.Domain.Common;

namespace BH.Assessment.Domain.Entities;

public class Transaction : AuditableEntity
{
    public Transaction()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public double Amount { get; set; }
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
}
using BH.Assessment.Domain.Common;

namespace BH.Assessment.Domain.Entities;

public class Customer : AuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public double Balance { get; set; }
}
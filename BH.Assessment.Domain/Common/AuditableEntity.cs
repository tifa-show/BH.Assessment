namespace BH.Assessment.Domain.Common;

public class AuditableEntity
{
    public string CreatedBy { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public string LastModifyBy { get; set; }
    public DateTimeOffset? LastModifiedDate { get; set; }
}
namespace CleanTeeth.Domain.Common;

public abstract class Auditable
{
    public string? CreatedBy { get; set; }
    public DateTimeOffset? CreationTime { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDate { get; set; }
}

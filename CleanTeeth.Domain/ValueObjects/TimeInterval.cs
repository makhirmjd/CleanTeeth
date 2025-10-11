namespace CleanTeeth.Domain.ValueObjects;

public record TimeInterval
{
    public DateTimeOffset Start { get; }
    public DateTimeOffset End { get; }
    public TimeInterval(DateTimeOffset start, DateTimeOffset end)
    {
        if (start > end)
        {
            throw new Exceptions.BusinessRuleException("The start time cannot be after the end time");
        }
        Start = start;
        End = end;
    }
}

namespace CleanTeeth.Domain.ValueObjects;

public record Email
{
    public string Value { get; }
    public Email(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new Exceptions.BusinessRuleException($"The {nameof(email)} is required");
        }

        if (!email.Contains('@'))
        {
            throw new Exceptions.BusinessRuleException($"The {nameof(email)} is not valid");
        }
        Value = email;
    }
}

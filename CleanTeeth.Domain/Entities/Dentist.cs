using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.Entities;

public class Dentist
{
    public Guid Id { get; }
    public string Name { get; private set; } = default!;
    public Email Email { get; private set; } = default!;

    public Dentist(string name, Email email)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exceptions.BusinessRuleException($"The {nameof(name)} is required");
        }

        if (email is null)
        {
            throw new Exceptions.BusinessRuleException($"The {nameof(email)} is required");
        }

        Id = Guid.CreateVersion7();
        Name = name;
        Email = email;
    }
}

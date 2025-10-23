using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.Entities;

public class Patient
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = default!;
    public Email Email { get; private set; } = default!;

    private Patient() { }

    public Patient(string name, Email email)
    {
        EnforceNameBusinessRules(name);

        EnforceEmailBusinessRules(email);

        Id = Guid.CreateVersion7();
        Name = name;
        Email = email;
    }

    public void UpdateName(string name)
    {
        EnforceNameBusinessRules(name);
        Name = name;
    }

    public void UpdateEmail(Email email)
    {
        EnforceEmailBusinessRules(email);
        Email = email;
    }

    private static void EnforceNameBusinessRules(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exceptions.BusinessRuleException($"The {nameof(name)} is required");
        }
    }

    private static void EnforceEmailBusinessRules(Email email)
    {
        if (email is null)
        {
            throw new Exceptions.BusinessRuleException($"The {nameof(email)} is required");
        }
    }
}

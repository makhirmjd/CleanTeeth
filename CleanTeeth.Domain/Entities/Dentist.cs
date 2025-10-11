namespace CleanTeeth.Domain.Entities;

public class Dentist
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;

    public Dentist(string name, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exceptions.BusinessRuleException($"The {nameof(name)} is required");
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new Exceptions.BusinessRuleException($"The {nameof(email)} is required");
        }

        if (!email.Contains('@'))
        {
            throw new Exceptions.BusinessRuleException($"The {nameof(email)} is not valid");
        }

        Id = Guid.CreateVersion7();
        Name = name;
        Email = email;
    }
}

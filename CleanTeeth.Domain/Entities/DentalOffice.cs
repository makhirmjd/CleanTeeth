namespace CleanTeeth.Domain.Entities;

public class DentalOffice
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = default!;

    public DentalOffice(string name)
    {
        EnforceBusinessRules(name);
        Id = Guid.CreateVersion7();
        Name = name;
    }

    public void UpdateName(string name)
    {
        EnforceBusinessRules(name);
        Name = name;
    }

    private static void EnforceBusinessRules(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exceptions.BusinessRuleException($"The {nameof(name)} is required");
        }
    }
}

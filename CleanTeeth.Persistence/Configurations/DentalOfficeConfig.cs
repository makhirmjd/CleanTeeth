using CleanTeeth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanTeeth.Persistence.Configurations;

public class DentalOfficeConfig : IEntityTypeConfiguration<DentalOffice>
{
    public void Configure(EntityTypeBuilder<DentalOffice> builder)
    {
        builder.Property(d => d.Name)
            .HasMaxLength(150)
            .IsRequired();
    }
}

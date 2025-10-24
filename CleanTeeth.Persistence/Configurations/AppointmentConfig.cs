using CleanTeeth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanTeeth.Persistence.Configurations;

public class AppointmentConfig : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ComplexProperty(prop => prop.TimeInterval, propBuilder =>
        {
            propBuilder.Property(ti => ti.Start).HasColumnName("StartDate");
            propBuilder.Property(ti => ti.End).HasColumnName("EndDate");
        });
    }
}

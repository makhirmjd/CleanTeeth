using CleanTeath.Application.Contracts.Security;
using CleanTeeth.Domain.Common;
using CleanTeeth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CleanTeeth.Persistence;

public class CleanTeethDbContext(DbContextOptions<CleanTeethDbContext> options, IUserService userService) : DbContext(options)
{
    public DbSet<DentalOffice> DentalOffices => Set<DentalOffice>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Dentist> Dentists => Set<Dentist>();
    public DbSet<Appointment> Appointments => Set<Appointment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly((typeof(CleanTeethDbContext)).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        if (userService is not null)
        {
            foreach (EntityEntry<Auditable> entry in ChangeTracker.Entries<Auditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreationTime = DateTimeOffset.UtcNow;
                        entry.Entity.CreatedBy = userService.GetUserId();
                        entry.Entity.LastModifiedDate = DateTimeOffset.UtcNow;
                        entry.Entity.LastModifiedBy = userService.GetUserId();
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTimeOffset.UtcNow;
                        entry.Entity.LastModifiedBy = userService.GetUserId();
                        break;
                }
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}

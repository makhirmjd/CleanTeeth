using CleanTeeth.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanTeeth.Persistence;

public class CleanTeethDbContext(DbContextOptions<CleanTeethDbContext> options) : DbContext(options)
{
    public DbSet<DentalOffice> DentalOffices => Set<DentalOffice>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Dentist> Dentists => Set<Dentist>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly((typeof(CleanTeethDbContext)).Assembly);
    }
}

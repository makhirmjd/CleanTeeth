using CleanTeeth.Security.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanTeeth.Security;

public class CleanTeethSecurityDbContext(DbContextOptions<CleanTeethSecurityDbContext> options) : IdentityDbContext<User>(options)
{
}

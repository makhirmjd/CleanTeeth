using CleanTeath.Application.Contracts.Security;
using CleanTeeth.Security.Models;
using CleanTeeth.Security.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanTeeth.Security;

public static class RegisterSecurityServices
{
    public static void AddSecurityServices(this IServiceCollection services)
    {
        services.AddAuthentication(IdentityConstants.BearerScheme).AddBearerToken(IdentityConstants.BearerScheme);

        services.AddAuthorizationBuilder()
            .AddPolicy("isadmin", policy => policy.RequireClaim("isadmin"));

        services.AddDbContext<CleanTeethSecurityDbContext>(options => options.UseSqlServer("name=CleanTeethConnectionString"));

        services.AddIdentityCore<User>()
            .AddEntityFrameworkStores<CleanTeethSecurityDbContext>()
            .AddApiEndpoints();

        services.AddHttpContextAccessor();
        services.AddTransient<IUserService, UserService>();
    }
}

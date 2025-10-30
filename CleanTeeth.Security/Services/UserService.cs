using CleanTeath.Application.Contracts.Security;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CleanTeeth.Security.Services;

public class UserService(IHttpContextAccessor httpContextAccessor) : IUserService
{
    public string GetUserId() =>
        httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
}

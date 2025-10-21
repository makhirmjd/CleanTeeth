using CleanTeath.Application.Utilities.Common;
using System.Text.Json;

namespace CleanTeeth.API.Utilities;

public static class HttpContextExtensions
{
    public static void InsertPaginationInformationInHeader(this HttpContext httpContext, MetaData metaData) =>
        httpContext.Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(metaData));
}

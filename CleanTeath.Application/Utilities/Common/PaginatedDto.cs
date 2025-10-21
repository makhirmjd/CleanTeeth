namespace CleanTeath.Application.Utilities.Common;

public class PaginatedDto<T>
{
    public List<T> Items { get; set; } = [];
    public int TotalAmountOfRecords { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int PageCount { get; set; }

    public MetaData ToMetaData() => new()
    {
        TotalAmountOfRecords = TotalAmountOfRecords,
        CurrentPage = CurrentPage,
        PageSize = PageSize,
        PageCount = PageCount
    };
}

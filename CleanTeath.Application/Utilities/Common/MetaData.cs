namespace CleanTeath.Application.Utilities.Common;

public class MetaData
{
    public int TotalAmountOfRecords { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int PageCount { get; set; }
    public bool HasNextPage => CurrentPage < PageCount;
    public bool HasPreviousPage => CurrentPage > 1;
}

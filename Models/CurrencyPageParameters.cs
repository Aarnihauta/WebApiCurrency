namespace WebApiCurrency.Models
{
public class CurrencyPageParameters
{
    public const int MaxPageSize = 5;
    public int PageNumber { get; set; } = 1;
    public int _pageSize;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
}
}

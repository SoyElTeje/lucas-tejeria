namespace FinanceManager.Models.CurrencyModels;

public class RetrieveCurrencyResponse
{
    public required string Id { get; set; }
    public required string Code { get; set; }
    public required string FullName { get; set; }
    public required string Symbol { get; set; }
}

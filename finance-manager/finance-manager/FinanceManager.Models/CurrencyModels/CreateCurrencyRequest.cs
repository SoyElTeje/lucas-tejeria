namespace FinanceManager.Models.CurrencyModels;

public class CreateCurrencyRequest
{
    public required string Code { get; set; }
    public required string FullName { get; set; }
    public required string Symbol { get; set; }
}

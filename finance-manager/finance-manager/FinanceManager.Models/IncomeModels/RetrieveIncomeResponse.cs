namespace FinanceManager.Models.IncomeModels;

public class RetrieveIncomeResponse
{
    public required string Id { get; set; }
    public required decimal Amount { get; set; }
    public required string CurrencyId { get; set; }
    public required string Description { get; set; }
    public required DateTime ReceivedAt { get; set; }
    public string? ScheduledIncomeId { get; set; }
}

namespace FinanceManager.Models.IncomeModels;

/// <summary>
/// DTO para actualización parcial (PATCH) de ingreso.
/// </summary>
public class UpdateIncomeRequest
{
    public required string Id { get; set; }
    public decimal? Amount { get; set; }
    public string? CurrencyId { get; set; }
    public DateTime? ReceivedAt { get; set; }
    public string? Description { get; set; }
    public string? ScheduledIncomeId { get; set; }
}

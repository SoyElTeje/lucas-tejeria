namespace FinanceManager.Models.ScheduledIncomeModels;

/// <summary>
/// DTO para actualización parcial (PATCH) de ingreso programado.
/// </summary>
public class UpdateScheduledIncomeRequest
{
    public required string Id { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? RecurrenceRuleId { get; set; }
}

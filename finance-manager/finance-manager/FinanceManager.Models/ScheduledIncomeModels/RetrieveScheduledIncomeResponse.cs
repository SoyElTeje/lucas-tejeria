namespace FinanceManager.Models.ScheduledIncomeModels;

public class RetrieveScheduledIncomeResponse
{
    public required string Id { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required string RecurrenceRuleId { get; set; }
}

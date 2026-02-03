namespace FinanceManager.Models.ScheduledIncomeModels;

public class CreateScheduledIncomeRequest
{
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    /// <summary>Id de la regla de recurrencia (RecurrenceRuleBase). La capa de aplicación debe resolverla a entidad.</summary>
    public required string RecurrenceRuleId { get; set; }
}

namespace FinanceManager.Models.RecurrenceRuleModels;

public class CreateEveryNDaysRuleRequest
{
    /// <summary>Id del usuario creador. La capa de aplicación debe resolverlo a entidad.</summary>
    public required string CreatorId { get; set; }
    public required string RuleName { get; set; }
    public required int NumberOfDays { get; set; }
}

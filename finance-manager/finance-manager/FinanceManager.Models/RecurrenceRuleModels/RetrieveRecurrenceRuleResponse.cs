namespace FinanceManager.Models.RecurrenceRuleModels;

/// <summary>
/// Respuesta genérica para una regla de recurrencia.
/// RuleType discrimina el tipo (ej. "EveryNDays"). NumberOfDays solo aplica para EveryNDays.
/// </summary>
public class RetrieveRecurrenceRuleResponse
{
    public required string Id { get; set; }
    public required string RuleName { get; set; }
    public required string CreatorId { get; set; }
    public required string RuleType { get; set; }
    /// <summary>Para EveryNDaysRule.</summary>
    public int? NumberOfDays { get; set; }
}

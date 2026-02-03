namespace FinanceManager.Models.RecurrenceRuleModels;

/// <summary>
/// DTO para actualización parcial (PATCH) de regla de recurrencia.
/// Para EveryNDaysRule se puede actualizar RuleName y/o NumberOfDays.
/// </summary>
public class UpdateRecurrenceRuleRequest
{
    public required string Id { get; set; }
    public string? RuleName { get; set; }
    /// <summary>Válido para reglas EveryNDays.</summary>
    public int? NumberOfDays { get; set; }
}

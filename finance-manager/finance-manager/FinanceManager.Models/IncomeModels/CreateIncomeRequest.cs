namespace FinanceManager.Models.IncomeModels;

public class CreateIncomeRequest
{
    public required decimal Amount { get; set; }
    /// <summary>Id de la moneda (Currency). La capa de aplicación debe resolverla a entidad.</summary>
    public required string CurrencyId { get; set; }
    public required DateTime ReceivedAt { get; set; }
    public required string Description { get; set; }
    /// <summary>Opcional. Id del ingreso programado asociado.</summary>
    public string? ScheduledIncomeId { get; set; }
}

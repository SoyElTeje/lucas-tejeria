namespace FinanceManager.Models.CurrencyModels;

/// <summary>
/// DTO para actualización parcial (PATCH) de moneda.
/// </summary>
public class UpdateCurrencyRequest
{
    public required string Id { get; set; }
    public string? Code { get; set; }
    public string? FullName { get; set; }
    public string? Symbol { get; set; }
}

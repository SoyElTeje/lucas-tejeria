namespace FinanceManager.Models.AccountModels;

/// <summary>
/// DTO para actualización parcial (PATCH) de cuenta.
/// </summary>
public class UpdateAccountRequest
{
    public required string Id { get; set; }
    public string? Name { get; set; }
    public string? CurrencyId { get; set; }
    public string? Description { get; set; }
}

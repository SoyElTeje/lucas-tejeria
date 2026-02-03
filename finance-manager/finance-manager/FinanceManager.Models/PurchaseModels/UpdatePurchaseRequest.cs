namespace FinanceManager.Models.PurchaseModels;

/// <summary>
/// DTO para actualización parcial (PATCH) de compra.
/// </summary>
public class UpdatePurchaseRequest
{
    public required string Id { get; set; }
    public DateTime? Date { get; set; }
    public string? Notes { get; set; }
}

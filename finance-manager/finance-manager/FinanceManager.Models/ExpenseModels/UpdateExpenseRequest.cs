namespace FinanceManager.Models.ExpenseModels;

/// <summary>
/// DTO para actualización parcial (PATCH) de gasto.
/// </summary>
public class UpdateExpenseRequest
{
    public required string Id { get; set; }
    public string? Name { get; set; }
    public decimal? Amount { get; set; }
    public string? TagId { get; set; }
}

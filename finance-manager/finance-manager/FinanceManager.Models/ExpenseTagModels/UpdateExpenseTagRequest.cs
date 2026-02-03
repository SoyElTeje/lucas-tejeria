namespace FinanceManager.Models.ExpenseTagModels;

/// <summary>
/// DTO para actualización parcial (PATCH) de etiqueta de gasto.
/// </summary>
public class UpdateExpenseTagRequest
{
    public required string Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? HexCode { get; set; }
    public string? IconUrl { get; set; }
}

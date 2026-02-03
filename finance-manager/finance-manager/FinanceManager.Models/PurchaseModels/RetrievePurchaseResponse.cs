namespace FinanceManager.Models.PurchaseModels;

public class RetrievePurchaseResponse
{
    public required string Id { get; set; }
    public required DateTime Date { get; set; }
    public required string Notes { get; set; }
    public required decimal Total { get; set; }
    /// <summary>Ids de los gastos (Expenses) de esta compra.</summary>
    public required IReadOnlyList<string> ExpenseIds { get; set; }
}

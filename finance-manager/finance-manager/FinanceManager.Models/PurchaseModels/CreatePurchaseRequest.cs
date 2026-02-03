namespace FinanceManager.Models.PurchaseModels;

public class CreatePurchaseRequest
{
    public required DateTime Date { get; set; }
    public required string Notes { get; set; }
}

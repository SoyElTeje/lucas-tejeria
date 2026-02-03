namespace FinanceManager.Models.ExpenseModels;

public class RetrieveExpenseResponse
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required decimal Amount { get; set; }
    public required string TagId { get; set; }
}

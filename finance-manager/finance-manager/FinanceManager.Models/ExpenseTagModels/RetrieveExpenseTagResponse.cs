namespace FinanceManager.Models.ExpenseTagModels;

public class RetrieveExpenseTagResponse
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string HexCode { get; set; }
    public required string IconUrl { get; set; }
    public required string CreatorId { get; set; }
}

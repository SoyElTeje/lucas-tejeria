namespace FinanceManager.Models.AccountModels;

public class RetrieveAccountResponse
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string CurrencyId { get; set; }
    public required decimal Balance { get; set; }
    public string? Description { get; set; }
    public required bool IsActive { get; set; }
    public required DateTime CreatedDate { get; set; }
}

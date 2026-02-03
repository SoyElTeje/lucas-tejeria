namespace FinanceManager.Models.AccountModels;

public class CreateAccountRequest
{
    public required string Name { get; set; }
    /// <summary>Id de la moneda (Currency). La capa de aplicación debe resolverla a entidad.</summary>
    public required string CurrencyId { get; set; }
    public required decimal InitialBalance { get; set; }
    public string? Description { get; set; }
}

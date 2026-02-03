namespace FinanceManager.Models.ExpenseModels;

public class CreateExpenseRequest
{
    public required string Name { get; set; }
    public required decimal Amount { get; set; }
    /// <summary>Id de la etiqueta (ExpenseTag). La capa de aplicación debe resolverla a entidad.</summary>
    public required string TagId { get; set; }
}

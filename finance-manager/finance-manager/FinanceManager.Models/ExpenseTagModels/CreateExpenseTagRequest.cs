namespace FinanceManager.Models.ExpenseTagModels;

public class CreateExpenseTagRequest
{
    /// <summary>Id del usuario creador. La capa de aplicación debe resolverlo a entidad.</summary>
    public required string CreatorId { get; set; }
    /// <summary>Id del color. La capa de aplicación debe resolverlo a entidad (tabla Colors).</summary>
    public required string ColorId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string IconUrl { get; set; }
}

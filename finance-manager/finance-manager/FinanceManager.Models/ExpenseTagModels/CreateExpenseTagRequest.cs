namespace FinanceManager.Models.ExpenseTagModels;

public class CreateExpenseTagRequest
{
    /// <summary>Id del usuario creador. La capa de aplicación debe resolverlo a entidad.</summary>
    public required string CreatorId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    /// <summary>Código hex del color (ej. #RRGGBB o RRGGBB).</summary>
    public required string HexCode { get; set; }
    public required string IconUrl { get; set; }
}

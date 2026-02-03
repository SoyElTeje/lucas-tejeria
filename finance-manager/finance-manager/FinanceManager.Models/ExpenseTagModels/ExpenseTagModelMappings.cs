using finance_manager;

namespace FinanceManager.Models.ExpenseTagModels;

public static class ExpenseTagModelMappings
{
    /// <summary>
    /// Requiere la entidad User (creador) y la entidad Color resueltas por la capa de aplicación.
    /// </summary>
    public static ExpenseTag ToEntity(this CreateExpenseTagRequest request, User creator, Color color)
    {
        return new ExpenseTag(creator, request.Name, request.Description, color, request.IconUrl);
    }

    public static RetrieveExpenseTagResponse ToResponse(this ExpenseTag tag)
    {
        return new RetrieveExpenseTagResponse
        {
            Id = tag.Id,
            Name = tag.Name,
            Description = tag.Description,
            ColorId = tag.ColorId,
            ColorName = tag.Color.Name,
            HexCode = tag.Color.HexCode,
            IconUrl = tag.IconUrl,
            CreatorId = tag.Creator.Id
        };
    }
}

using finance_manager;
using Shared;

namespace FinanceManager.Models.ExpenseTagModels;

public static class ExpenseTagModelMappings
{
    /// <summary>
    /// Requiere la entidad User (creador) resuelta. El color se crea desde HexCode.
    /// </summary>
    public static ExpenseTag ToEntity(this CreateExpenseTagRequest request, User creator)
    {
        var color = new Color(request.HexCode);
        return new ExpenseTag(creator, request.Name, request.Description, color, request.IconUrl);
    }

    public static RetrieveExpenseTagResponse ToResponse(this ExpenseTag tag)
    {
        return new RetrieveExpenseTagResponse
        {
            Id = tag.Id,
            Name = tag.Name,
            Description = tag.Description,
            HexCode = tag.Color.HexCode,
            IconUrl = tag.IconUrl,
            CreatorId = tag.Creator.Id
        };
    }
}

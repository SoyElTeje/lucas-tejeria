using finance_manager;

namespace FinanceManager.Models.ColorModels;

public static class ColorModelMappings
{
    public static Color ToEntity(this CreateColorRequest request)
    {
        return new Color(request.Name, request.HexCode);
    }

    public static RetrieveColorResponse ToResponse(this Color color)
    {
        return new RetrieveColorResponse
        {
            Id = color.Id,
            Name = color.Name,
            HexCode = color.HexCode
        };
    }
}

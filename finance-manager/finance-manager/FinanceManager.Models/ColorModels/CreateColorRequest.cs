namespace FinanceManager.Models.ColorModels;

public class CreateColorRequest
{
    /// <summary>Nombre del color para mostrar en pantalla.</summary>
    public required string Name { get; set; }
    /// <summary>Código hex (ej. #RRGGBB o RRGGBB). Se normaliza con #.</summary>
    public required string HexCode { get; set; }
}

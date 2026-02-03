namespace FinanceManager.Models.ColorModels;

/// <summary>
/// DTO para actualización parcial (PATCH) de color.
/// </summary>
public class UpdateColorRequest
{
    public required string Id { get; set; }
    public string? Name { get; set; }
    public string? HexCode { get; set; }
}

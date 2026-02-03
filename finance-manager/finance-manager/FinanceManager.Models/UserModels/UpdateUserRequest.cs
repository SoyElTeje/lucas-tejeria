namespace FinanceManager.Models.UserModels;

/// <summary>
/// DTO para actualización parcial (PATCH) de usuario.
/// Solo los campos no nulos se aplican; Id es obligatorio para identificar al usuario.
/// </summary>
public class UpdateUserRequest
{
    public required string Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Password { get; set; }
}
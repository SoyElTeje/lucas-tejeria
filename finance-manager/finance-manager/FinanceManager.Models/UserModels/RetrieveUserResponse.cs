namespace FinanceManager.Models.UserModels;

/// <summary>
/// DTO devuelto al obtener un usuario (retrieve/get).
/// </summary>
public class RetrieveUserResponse
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public required DateTime BirthDate { get; set; }
}

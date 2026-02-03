namespace FinanceManager.Models.UserModels;

public class CreateUserRequest
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required DateTime BirthDate { get; set; }
    public required string Surname { get; set; }
}
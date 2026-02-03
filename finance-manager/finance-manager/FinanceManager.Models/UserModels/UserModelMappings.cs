using finance_manager;

namespace FinanceManager.Models.UserModels;

/// <summary>
/// Mapeos entre DTOs de usuario y entidad de dominio.
/// El mapeo queda fuera de los DTOs para mantenerlos sin lógica y desacoplados.
/// </summary>
public static class UserModelMappings
{
    public static User ToEntity(this CreateUserRequest request)
    {
        return new User(request.Name, request.Surname, request.Email, request.Password, request.BirthDate);
    }

    public static RetrieveUserResponse ToResponse(this User user)
    {
        return new RetrieveUserResponse
        {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email,
            BirthDate = user.BirthDate
        };
    }
}

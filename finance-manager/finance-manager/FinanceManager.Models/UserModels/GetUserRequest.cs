namespace FinanceManager.Models.UserModels;

/// <summary>
/// Request mínimo para obtener un usuario por identificador.
/// Usado cuando el cliente solicita un usuario (ej. GET /users/{id} en body o query).
/// </summary>
public class GetUserRequest
{
    public required string Id { get; set; }
}

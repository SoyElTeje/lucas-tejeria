using finance_manager;

namespace FinanceManager.Models.AccountModels;

public static class AccountModelMappings
{
    /// <summary>
    /// Requiere la entidad Currency resuelta (por ejemplo desde el repositorio).
    /// </summary>
    public static Account ToEntity(this CreateAccountRequest request, Currency currency)
    {
        return string.IsNullOrWhiteSpace(request.Description)
            ? new Account(request.Name, currency, request.InitialBalance)
            : new Account(request.Name, currency, request.InitialBalance, request.Description);
    }

    public static RetrieveAccountResponse ToResponse(this Account account)
    {
        return new RetrieveAccountResponse
        {
            Id = account.Id,
            Name = account.Name,
            CurrencyId = account.CurrencyId,
            Balance = account.Balance,
            Description = account.Description,
            IsActive = account.IsActive,
            CreatedDate = account.CreatedDate
        };
    }
}

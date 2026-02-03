using finance_manager;

namespace FinanceManager.Models.IncomeModels;

public static class IncomeModelMappings
{
    /// <summary>
    /// Requiere la entidad Currency. Si hay ScheduledIncomeId, la capa de aplicación debe pasar la entidad ScheduledIncome (puede ser null).
    /// </summary>
    public static Income ToEntity(this CreateIncomeRequest request, Currency currency, ScheduledIncome? scheduledIncome = null)
    {
        return scheduledIncome is null
            ? new Income(request.Amount, currency, request.ReceivedAt, request.Description)
            : new Income(request.Amount, currency, request.ReceivedAt, request.Description, scheduledIncome);
    }

    public static RetrieveIncomeResponse ToResponse(this Income income)
    {
        return new RetrieveIncomeResponse
        {
            Id = income.Id,
            Amount = income.Amount,
            CurrencyId = income.CurrencyId,
            Description = income.Description,
            ReceivedAt = income.ReceivedAt,
            ScheduledIncomeId = income.ScheduledIncome?.Id
        };
    }
}

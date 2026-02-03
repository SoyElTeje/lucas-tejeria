using finance_manager;

namespace FinanceManager.Models.ScheduledIncomeModels;

public static class ScheduledIncomeModelMappings
{
    /// <summary>
    /// Requiere la entidad RecurrenceRule (o RecurrenceRuleBase) resuelta.
    /// </summary>
    public static ScheduledIncome ToEntity(this CreateScheduledIncomeRequest request, RecurrenceRule recurrenceRule)
    {
        return new ScheduledIncome(request.StartDate, request.EndDate, recurrenceRule);
    }

    public static RetrieveScheduledIncomeResponse ToResponse(this ScheduledIncome scheduledIncome)
    {
        return new RetrieveScheduledIncomeResponse
        {
            Id = scheduledIncome.Id,
            StartDate = scheduledIncome.StartDate,
            EndDate = scheduledIncome.EndDate,
            RecurrenceRuleId = scheduledIncome.RecurrenceRule.Id
        };
    }
}

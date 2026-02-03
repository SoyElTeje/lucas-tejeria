using finance_manager;

namespace FinanceManager.Models.RecurrenceRuleModels;

public static class RecurrenceRuleModelMappings
{
    /// <summary>
    /// Requiere la entidad User (creador) resuelta. Crea una EveryNDaysRule.
    /// </summary>
    public static EveryNDaysRule ToEntity(this CreateEveryNDaysRuleRequest request, User creator)
    {
        return new EveryNDaysRule(creator, request.NumberOfDays, request.RuleName);
    }

    public static RetrieveRecurrenceRuleResponse ToResponse(this RecurrenceRuleBase rule)
    {
        var response = new RetrieveRecurrenceRuleResponse
        {
            Id = rule.Id,
            RuleName = rule.RuleName,
            CreatorId = rule.Creator.Id,
            RuleType = rule.GetType().Name
        };

        if (rule is EveryNDaysRule everyNDays)
        {
            response.RuleType = "EveryNDays";
            response.NumberOfDays = everyNDays.NumberOfDays;
        }

        return response;
    }
}

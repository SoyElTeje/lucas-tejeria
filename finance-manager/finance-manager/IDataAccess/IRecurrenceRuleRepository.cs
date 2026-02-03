using finance_manager;

namespace IDataAccess;

public interface IRecurrenceRuleRepository
{
    RecurrenceRuleBase? GetById(string ruleId);
    List<RecurrenceRuleBase> GetByCreatorId(string userId);
    bool Add(RecurrenceRuleBase rule);
    bool Update(RecurrenceRuleBase rule);
    bool Delete(RecurrenceRuleBase rule);
}

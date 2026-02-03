using finance_manager;

namespace IDataAccess;

public interface IScheduledIncomeRepository
{
    ScheduledIncome? GetById(string scheduledIncomeId);
    List<ScheduledIncome> GetAll();
    bool Add(ScheduledIncome scheduledIncome);
    bool Update(ScheduledIncome scheduledIncome);
    bool Delete(ScheduledIncome scheduledIncome);
}

using finance_manager;

namespace IDataAccess;

public interface IIncomeRepository
{
    Income? GetById(string incomeId);
    List<Income> GetAll();
    List<Income> GetByScheduledIncomeId(string scheduledIncomeId);
    bool Add(Income income);
    bool Update(Income income);
    bool Delete(Income income);
}

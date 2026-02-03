using finance_manager;

namespace IDataAccess;

public interface IExpenseTagRepository
{
    bool AddExpenseTag(ExpenseTag expenseTag);
    bool UpdateExpenseTag(ExpenseTag expenseTag);
    bool DeleteExpenseTag(ExpenseTag expenseTag);
    ExpenseTag? GetExpenseTagById(string expenseTagId);
    List<ExpenseTag> GetExpenseTags();
}